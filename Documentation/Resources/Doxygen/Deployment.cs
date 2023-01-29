/*!
  \page PageDeployment Deployment
  \tableofcontents
  \section SectionServer Server
  \subsection SubsectionBuild 1. Building
  -# Open project in Unity.
  -# Switch platform to Dedicated Server. Verify type is set to Linux.
  -# Build app.
    - The target build directory will be zipped in an upcoming next step, therefore, it makes sense to build to a directory named appropriately (e.g. VerseServer-Dev).
  \subsection SectionUpload 2. Uploading
  -# Delete the debug directory created.
  -# Zip the directory.
  -# Copy the project to the server<br/>
    `scp ./VerseServer-Dev.zip <username>@<ip address>:~`
  -# Log into the server<br/>
    `ssh <username>@<ip address>`
  -# Check if the server is running<br/>
    `ps -ef | grep "Server"`
    - If the server is running, kill it<br/>
    `kill -9 <process ID>`
  -# Execute the following
  \code{.sh}
  rm -rf ./VerseServer-Dev
  unzip ./VerseServer-Dev.zip
  rm ./VerseServer-Dev.zip
  cp ./cert/* ./VerseServer-Dev
  cd ./VerseServer-Dev
  chmod +x ./VerseServer-Dev.x86_64
  ./VerseServer-Dev.x86_64
  \endcode
  
  \section SectionUsefulBashCommands Useful Server Commands
  
  - \code{.sh}
  nohup ./VerseServer-Dev.x86_64 > out.txt & disown
  \endcode
    - When executed in the `VerseServer-Dev` directory, this will execute the dev server in the background with the output sent to `out.txt`.
  - \code{.sh}
  tail -f ./out.txt
  \endcode
    - Use this to watch the output of the server sent to `out.txt`.

  \section SectionUsefulADBCommands Useful ADB Commands

  - \code{.sh}
  adb kill-server
  \endcode
    - Kills the ADB server.
  - \code{.sh}
  adb tcpip 5555
  \endcode
    - Starts the ADB server listening to port 5555.
  - \code{.sh}
  adb devices
  \endcode
    - Lists devices connected to ADB.
  - \code{.sh}
  adb connect <ip address>
  \endcode
    - Establishes a wireless ADB connection to the specified device.
  - \code{.sh}
  adb logcat -c
  \endcode
    - Clears the ADB log.
  - \code{.sh}
  adb logcat -s Unity
  \endcode
    - Use this to watch Unity ADB log output.
  - \code{.sh}
  adb shell setprop debug.oculus.refreshrate 60
  \endcode
    - Locks the device to 60 FPS.
  - \code{.sh}
  adb shell setprop debug.oculus.cpulevel 2
  \endcode
    - Locks the device's CPU level to 2.
  - \code{.sh}
  adb shell setprop debug.oculus.gpulevel 2
  \endcode
    - Locks the device's GPU level to 2.
  - \code{.sh}
  adb shell setprop debug.oculus.foveation.level 0
  \endcode
    - Locks the device's foveation level to 0.
	
*/
 
