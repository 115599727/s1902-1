using PylonC.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Camera
{
    public class BalserA1440OverlappedGrab : IGrabImage
    {

        uint NUM_GRABS = 2008;          /* Number of images to grab. */
        const uint NUM_BUFFERS = 5;         /* Number of buffers used for grabbing. */
        static List<ShotImage> ResultList ;
        private string SettingFile;
        private string CameraName;
        

        public int SetNUM_GRABS
        {
            set {
                
                NUM_GRABS = Convert.ToUInt32(value);
            }
        }
        public BalserA1440OverlappedGrab(string settingfile,string cameraName)
        {
            //SettingFile = "c:\\acA1440-220um_40021038.pfs";
            this.SettingFile = settingfile;
            this.CameraName = cameraName;
            

        }
        public List<ShotImage> ResultImageList
        {
            get
            {
                return ResultList;
            }
        }

        public void GrabImage()
        {
            // RunShot();
            PYLON_DEVICE_HANDLE hDev = new PYLON_DEVICE_HANDLE(); /* Handle for the pylon device. */
            try
            {
                uint numDevices;               /* Number of available devices. */
                PYLON_STREAMGRABBER_HANDLE hGrabber;  /* Handle for the pylon stream grabber. */
                PYLON_WAITOBJECT_HANDLE hWait;        /* Handle used for waiting for a grab to be finished. */
                uint payloadSize;              /* Size of an image frame in bytes. */
                Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>> buffers; /* Holds handles and buffers used for grabbing. */
                PylonGrabResult_t grabResult;               /* Stores the result of a grab operation. */
                int nGrabs;                   /* Counts the number of buffers grabbed. */
                uint nStreams;                 /* The number of streams provides by the device.  */
                bool isAvail;                  /* Used for checking feature availability. */
                bool isReady;                  /* Used as an output parameter. */
                int i;                        /* Counter. */



                /* Before using any pylon methods, the pylon runtime must be initialized. */
                Pylon.Initialize();

                /* Enumerate all camera devices. You must call
                PylonEnumerateDevices() before creating a device. */
                numDevices = Pylon.EnumerateDevices();

                if (0 == numDevices)
                {
                    throw new Exception("No Balser  devices found.");
                }


                /* Get a handle for the first device found.  */
                hDev = Pylon.CreateDeviceByIndex(GetCamraIndex());

                /* ... Close and release the pylon device. */
                if (Pylon.DeviceIsOpen(hDev))
                {
                    Pylon.DeviceClose(hDev);
                }
                /* Before using the device, it must be opened. Open it for configuring
                parameters and for grabbing images. */
                Pylon.DeviceOpen(hDev, Pylon.cPylonAccessModeControl | Pylon.cPylonAccessModeStream);

                NODEMAP_HANDLE h_Node = Pylon.DeviceGetNodeMap(hDev);
                Pylon.FeaturePersistenceLoad(h_Node, SettingFile, true);




                /* Print out the name of the camera we are using. */
                {
                    bool isReadable = Pylon.DeviceFeatureIsReadable(hDev, "DeviceModelName");
                    if (isReadable)
                    {
                        string name = Pylon.DeviceFeatureToString(hDev, "DeviceModelName");
                        Console.WriteLine("Using camera {0}.", name);
                    }
                }

                /* Set the pixel format to Mono8, where gray values will be output as 8 bit values for each pixel. */
                /* ... Check first to see if the device supports the Mono8 format. */
                //isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_PixelFormat_Mono8");

                //if (!isAvail)
                //{
                //    /* Feature is not available. */
                //    throw new Exception("Device doesn't support the Mono8 pixel format.");
                //}
                ///* ... Set the pixel format to Mono8. */
                //Pylon.DeviceFeatureFromString(hDev, "PixelFormat", "Mono8");

                ///* Disable acquisition start trigger if available */
                //isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_TriggerSelector_AcquisitionStart");
                //if (isAvail)
                //{
                //    Pylon.DeviceFeatureFromString(hDev, "TriggerSelector", "AcquisitionStart");
                //    Pylon.DeviceFeatureFromString(hDev, "TriggerMode", "Off");
                //}

                ///* Disable frame burst start trigger if available */
                //isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_TriggerSelector_FrameBurstStart");
                //if (isAvail)
                //{
                //    Pylon.DeviceFeatureFromString(hDev, "TriggerSelector", "FrameBurstStart");
                //    Pylon.DeviceFeatureFromString(hDev, "TriggerMode", "Off");
                //}

                ///* Disable frame start trigger if available */
                //isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_TriggerSelector_FrameStart");
                //if (isAvail)
                //{
                //    Pylon.DeviceFeatureFromString(hDev, "TriggerSelector", "FrameStart");
                //    Pylon.DeviceFeatureFromString(hDev, "TriggerMode", "Off");
                //}

                /* We will use the Continuous frame mode, i.e., the camera delivers
                images continuously. */
                Pylon.DeviceFeatureFromString(hDev, "AcquisitionMode", "Continuous");

                /* For GigE cameras, we recommend increasing the packet size for better
                   performance. When the network adapter supports jumbo frames, set the packet
                   size to a value > 1500, e.g., to 8192. In this sample, we only set the packet size
                   to 1500. */
                /* ... Check first to see if the GigE camera packet size parameter is supported and if it is writable. */
                isAvail = Pylon.DeviceFeatureIsWritable(hDev, "GevSCPSPacketSize");
                if (isAvail)
                {
                    /* ... The device supports the packet size feature. Set a value. */
                    Pylon.DeviceSetIntegerFeature(hDev, "GevSCPSPacketSize", 1500);
                }

                /* Determine the required size of the grab buffer. */
                payloadSize = checked((uint)Pylon.DeviceGetIntegerFeature(hDev, "PayloadSize"));

                /* Image grabbing is done using a stream grabber.
                  A device may be able to provide different streams. A separate stream grabber must
                  be used for each stream. In this sample, we create a stream grabber for the default
                  stream, i.e., the first stream ( index == 0 ).
                  */

                /* Get the number of streams supported by the device and the transport layer. */
                nStreams = Pylon.DeviceGetNumStreamGrabberChannels(hDev);

                if (nStreams < 1)
                {
                    throw new Exception("The transport layer doesn't support image streams.");
                }

                /* Create and open a stream grabber for the first channel. */
                hGrabber = Pylon.DeviceGetStreamGrabber(hDev, 0);
                Pylon.StreamGrabberOpen(hGrabber);

                /* Get a handle for the stream grabber's wait object. The wait object
                   allows waiting for buffers to be filled with grabbed data. */
                hWait = Pylon.StreamGrabberGetWaitObject(hGrabber);

                /* We must tell the stream grabber the number and size of the buffers
                    we are using. */
                /* .. We will not use more than NUM_BUFFERS for grabbing. */
                Pylon.StreamGrabberSetMaxNumBuffer(hGrabber, NUM_BUFFERS);

                /* .. We will not use buffers bigger than payloadSize bytes. */
                Pylon.StreamGrabberSetMaxBufferSize(hGrabber, payloadSize);

                /*  Allocate the resources required for grabbing. After this, critical parameters
                    that impact the payload size must not be changed until FinishGrab() is called. */
                Pylon.StreamGrabberPrepareGrab(hGrabber);

                /* Before using the buffers for grabbing, they must be registered at
                   the stream grabber. For each registered buffer, a buffer handle
                   is returned. After registering, these handles are used instead of the
                   buffer objects pointers. The buffer objects are held in a dictionary,
                   that provides access to the buffer using a handle as key.
                 */
                buffers = new Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>();


                for (i = 0; i < NUM_BUFFERS; ++i)
                {
                    PylonBuffer<Byte> buffer = new PylonBuffer<byte>(payloadSize, true);
                    PYLON_STREAMBUFFER_HANDLE handle = Pylon.StreamGrabberRegisterBuffer(hGrabber, ref buffer);
                    buffers.Add(handle, buffer);
                }

                /* Feed the buffers into the stream grabber's input queue. For each buffer, the API
                   allows passing in an integer as additional context information. This integer
                   will be returned unchanged when the grab is finished. In our example, we use the index of the
                   buffer as context information. */
                i = 0;
                foreach (KeyValuePair<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>> pair in buffers)
                {
                    Pylon.StreamGrabberQueueBuffer(hGrabber, pair.Key, i++);
                }


                /* The stream grabber is now prepared. As soon the camera starts acquiring images,
                   the image data will be grabbed into the provided buffers.  */

                /* Let the camera acquire images. */
                Pylon.DeviceExecuteCommandFeature(hDev, "AcquisitionStart");

                /* Grab NUM_GRABS images */
                nGrabs = 0;                         /* Counts the number of grabbed images. */
                ResultList = new List<ShotImage>(Convert.ToInt32(NUM_BUFFERS));
                while (nGrabs < NUM_GRABS)
                {
                    int bufferIndex;                /* Index of the buffer. */
                    Byte min, max;
                    /* Wait for the next buffer to be filled. Wait up to 1000 ms. */
                    isReady = Pylon.WaitObjectWait(hWait, 10000);

                    if (!isReady)
                    {
                        /* Timeout occurred. */
                        Console.WriteLine("Ready false");
                        throw new Exception("Grab timeout occurred.");
                    }

                    /* Since the wait operation was successful, the result of at least one grab
                       operation is available. Retrieve it. */
                    isReady = Pylon.StreamGrabberRetrieveResult(hGrabber, out grabResult);

                    if (!isReady)
                    {
                        /* Oops. No grab result available? We should never have reached this point.
                           Since the wait operation above returned without a timeout, a grab result
                           should be available. */
                        throw new Exception("Failed to retrieve a grab result");
                    }

                    nGrabs++;
                    Console.WriteLine(nGrabs);
                    /* Get the buffer index from the context information. */
                    bufferIndex = (int)grabResult.Context;

                    /* Check to see if the image was grabbed successfully. */
                    if (grabResult.Status == EPylonGrabStatus.Grabbed)
                    {
                        /*  Success. Perform image processing. Since we passed more than one buffer
                        to the stream grabber, the remaining buffers are filled in the background while
                        we do the image processing. The processed buffer won't be touched by
                        the stream grabber until we pass it back to the stream grabber. */

                        PylonBuffer<Byte> buffer;        /* Reference to the buffer attached to the grab result. */

                        /* Get the buffer from the dictionary. Since we also got the buffer index,
                           we could alternatively use an array, e.g. buffers[bufferIndex]. */
                        if (!buffers.TryGetValue(grabResult.hBuffer, out buffer))
                        {
                            /* Oops. No buffer available? We should never have reached this point. Since all buffers are
                               in the dictionary. */
                            throw new Exception("Failed to find the buffer associated with the handle returned in grab result.");
                        }

                        /* Perform processing. */
                        //getMinMax(buffer.Array, grabResult.SizeX, grabResult.SizeY, out min, out max);
                        //    Console.WriteLine("Grabbed frame {0} into buffer {1}. Min. gray value = {2}, Max. gray value = {3}",
                        //    nGrabs, bufferIndex, min, max);
                        ShotImage img = new ShotImage(grabResult.SizeX, grabResult.SizeY, buffer.Array, false, grabResult.TimeStamp);
                        ResultList.Add(img);
                        // Console.WriteLine("Grabbed frame {0} into buffer {1}. Min. gray value = {2}, Max. gray value = {3}",
                        //     nGrabs, bufferIndex, 1, 1);
                        //Console.Error.WriteLine(ResultList.Capacity + "/" + ResultList.Count);
                        /* Display image */
                        //Pylon.ImageWindowDisplayImage<Byte>(0, buffer, grabResult);
                    }
                    else if (grabResult.Status == EPylonGrabStatus.Failed)
                    {
                        Console.Error.WriteLine("Frame {0} wasn't grabbed successfully.  Error code = {1}",
                            nGrabs, grabResult.ErrorCode);
                    }

                    /* Once finished with the processing, requeue the buffer to be filled again. */
                    Pylon.StreamGrabberQueueBuffer(hGrabber, grabResult.hBuffer, bufferIndex);
                }

                /* Clean up. */

                /*  ... Stop the camera. */
                Pylon.DeviceExecuteCommandFeature(hDev, "AcquisitionStop");

                /* ... We must issue a cancel call to ensure that all pending buffers are put into the
                   stream grabber's output queue. */
                Pylon.StreamGrabberCancelGrab(hGrabber);

                /* ... The buffers can now be retrieved from the stream grabber. */
                do
                {
                    isReady = Pylon.StreamGrabberRetrieveResult(hGrabber, out grabResult);

                } while (isReady);

                /* ... When all buffers are retrieved from the stream grabber, they can be deregistered.
                       After deregistering the buffers, it is safe to free the memory. */

                foreach (KeyValuePair<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>> pair in buffers)
                {
                    Pylon.StreamGrabberDeregisterBuffer(hGrabber, pair.Key);
                    pair.Value.Dispose();
                }
                buffers = null;

                /* ... Release grabbing related resources. */
                Pylon.StreamGrabberFinishGrab(hGrabber);

                /* After calling PylonStreamGrabberFinishGrab(), parameters that impact the payload size (e.g.,
                the AOI width and height parameters) are unlocked and can be modified again. */

                /* ... Close the stream grabber. */
                Pylon.StreamGrabberClose(hGrabber);

                /* ... Close and release the pylon device. The stream grabber becomes invalid
                   after closing the pylon device. Don't call stream grabber related methods after
                   closing or releasing the device. */
                Pylon.DeviceClose(hDev);
                Pylon.DestroyDevice(hDev);
                //SaveImage();
                Console.Error.WriteLine(ResultList.Capacity + "/" + ResultList.Count);
                //Console.Error.WriteLine("\nPress enter to exit.1");
                //Console.ReadLine();

                /* ... Shut down the pylon runtime system. Don't call any pylon method after
                   calling Pylon.Terminate(). */
                Pylon.Terminate();
            }
            catch (Exception e)
            {

                /* Retrieve the error message. */
                string msg = GenApi.GetLastErrorMessage() + "\n" + GenApi.GetLastErrorDetail();
                Console.Error.WriteLine("Exception caught:");
                Console.Error.WriteLine(e.Message);
                if (msg != "\n")
                {
                    Console.Error.WriteLine("Last error message:");
                    Console.Error.WriteLine(msg);
                }

                try
                {
                    if (hDev.IsValid)
                    {
                        /* ... Close and release the pylon device. */
                        if (Pylon.DeviceIsOpen(hDev))
                        {
                            Pylon.DeviceClose(hDev);
                        }
                        Pylon.DestroyDevice(hDev);
                    }
                }
                catch (Exception)
                {
                    /*No further handling here.*/

                }

                Pylon.Terminate();  /* Releases all pylon resources. */
                
                throw e;
                //Console.Error.WriteLine("\nPress enter to exit.0");
                //Console.Error.WriteLine(ResultList.Capacity + "/" + ResultList.Count);

                //Console.ReadLine();

                // Environment.Exit(1);
            }
        }

        public void SaveImage(string path = "e:\\cimage\\")
        {
            int fileNo = 1;

            foreach (var item in ResultList)
            {
                Bitmap bmap = new Bitmap(item.Width, item.Height, PixelFormat.Format8bppIndexed);
                BitmapFactory.CreateBitmap(out bmap, item.Width, item.Height, false);
                BitmapFactory.UpdateBitmap(bmap, item.Buffer, item.Width, item.Height, false);
                //Console.WriteLine(item.Buffer.Length + "");
                string strt = item.CreateTime.Hour + "_" + item.CreateTime.Minute + "_" + item.CreateTime.Second;
                bmap.Save(path + fileNo + "n" + strt + ".bmp", ImageFormat.Bmp);
                fileNo++;

            }

        }

        /* Simple "image processing" function returning the minimum and maximum gray
        value of an 8 bit gray value image. */
        static void getMinMax(Byte[] imageBuffer, long width, long height, out Byte min, out Byte max)
        {
            min = 255; max = 0;
            long imageDataSize = width * height;

            for (long i = 0; i < imageDataSize; ++i)
            {
                Byte val = imageBuffer[i];
                if (val > max)
                    max = val;
                if (val < min)
                    min = val;
            }
        }
        /// <summary>
        /// 相机已连接操作
        /// </summary>
        /// <returns></returns>
        public bool IsCameraConnected()
        {

            uint cindex = GetCamraIndex();
             if(cindex >= 0)
                return true;
            else
                return false;

        }

        uint GetCamraIndex()
        {
            foreach (var item in DeviceEnumerator.EnumerateDevices())
            {
                if (item.Name.Equals(this.CameraName))
                {
                    return item.Index;
                }
            }

            throw new Exception(this.CameraName + "不存在，请检测相机连接线缆。");
        }

    }
    /// <summary>
    /// 相机枚举
    /// </summary>
    public static class DeviceEnumerator
    {
        /* Data class used for holding device data. */
        public class Device
        {
            public string Name; /* The friendly name of the device. */
            public string FullName; /* The full name string which is unique. */
            public uint Index; /* The index of the device. */
            public string Tooltip; /* The displayed tooltip */

        }

        /* Queries the number of available devices and creates a list with device data. */
        public static List<Device> EnumerateDevices()
        {
            Pylon.Initialize();
            /* Create a list for the device data. */
            List<Device> list = new List<Device>();

            /* Enumerate all camera devices. You must call
            PylonEnumerateDevices() before creating a device. */
            uint count = Pylon.EnumerateDevices();

            /* Get device data from all devices. */
            for (uint i = 0; i < count; ++i)
            {
                /* Create a new data packet. */
                Device device = new Device();
                /* Get the device info handle of the device. */
                PYLON_DEVICE_INFO_HANDLE hDi = Pylon.GetDeviceInfoHandle(i);
                /* Get the name. */
                device.Name = Pylon.DeviceInfoGetPropertyValueByName(hDi, Pylon.cPylonDeviceInfoFriendlyNameKey);
                /* Get the serial number */
                device.FullName = Pylon.DeviceInfoGetPropertyValueByName(hDi, Pylon.cPylonDeviceInfoFullNameKey);
                /* Set the index. */
                device.Index = i;

                /* Create tooltip */
                string tooltip = "";
                uint propertyCount = Pylon.DeviceInfoGetNumProperties(hDi);

                if (propertyCount > 0)
                {
                    for (uint j = 0; j < propertyCount; j++)
                    {
                        tooltip += Pylon.DeviceInfoGetPropertyName(hDi, j) + ": " + Pylon.DeviceInfoGetPropertyValueByIndex(hDi, j);
                        if (j != propertyCount - 1)
                        {
                            tooltip += "\n";
                        }
                    }
                }
                device.Tooltip = tooltip;
                /* Add to the list. */
                list.Add(device);
            }
            return list;
        }
    }
}
