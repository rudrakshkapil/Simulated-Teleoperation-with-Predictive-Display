# Simulated Robotic Arm Teleoperation using Predictive Display
This is our project's code repository for the CMPUT 615 3D Computer Vision course during the Winter '22 term.

Group members:
- Rudraksh Kapil (rkapil@ualberta.ca)
- Raghav Madan (rmadan2@ualberta.ca)



## Pre-requisites
Getting this project to build and run properly can be tricky as it needs very specific versions of the different required software. The information in this section should be descriptive enough to guide you through the process correctly, but if you face any issues feel free to reach out to either of the group members.

#### Operating System
Ubuntu is needed to run ROS and ORB-SLAM. We recommend using Ubuntu 18.04.3 LTS.

#### Unity Hub and Editor 
The easiest way to open Unity 3D projects and install editors is by first [installing Unity Hub](https://docs.unity3d.com/2020.1/Documentation/Manual/GettingStartedInstallingHub.html).

Unity 3D projects should be opened with the editor version they were created with. Otherwise the project would need to be upgraded and may cause minor issues. Therefore we recommend version 2020.3.32f1. You don't need to install any of the large build packages as the game can run from the editor itself.

#### ORB-SLAM 2 Pre-requisites
The required software for ORB-SLAM can be found on its [GitHub page](https://github.com/raulmur/ORB_SLAM2). However, very specific versions of some of these need to be installed to run with CARV.

**Specific versions:**
1. OpenCV -- 3.2
2. Eigen -- 3.2.10

#### ROS
ROS Melodic is the distro we worked with. Installation instructions are [here](http://wiki.ros.org/melodic/Installation/Ubuntu). 



## Build Instructions

1. Delete all the old build folders in the thirdparty folders `/CARV/ThirdParty/<all subdirectories>`.


2. Build CARV
```bash
cd /CARV
chmod +x ./build.sh
./build.sh

```
3. Set ROS_PACKAGE_PATH environment variable (and confirm).
```bash
export ROS_PACKAGE_PATH=${ROS_PACKAGE_PATH}:<path-to-repo>/CARV/Examples/ROS
echo $ROS_PACKAGE_PATH
```

4. Build ROS
```bash
chmod +x ./build_ros.sh
./build_ros.sh
```

5. Open Unity Hub, add `/ArmRobot` to the projects list, and specifiy editor version.



## Run Instructions

1. Open the game scene in the Unity project.

2. Source bash to run with ROS. This needs to be done for every new terminal you open -- you need 3 in total.
```bash
source <path-to-repo>/CARV/Examples/ROS/ORB_CARV_Pub/build/devel/setup.bash
```

3. **Terminal 1:** Run ROSBridge Sever
```bash
roslaunch rosbridge_server rosbridge_websocket.launch
```

4. **Terminal 2:** Image Transport for extra compression
```bash
rosrun image_transport republish compressed in:=/image_transport raw out:=/chris/image
```

5. **Terminal 3:** Run ORB-CARV node
```bash
rosrun ORB_CARV_Pub Mono Vocabulary/ORBvoc.txt chris_logic_HD720.yaml /camera/image_raw:=/chris/image
```

6. Hit play in Unity Editor -- the game should start. A ps4 controller or the keys WASDQEPO can be used to move the robot. Space and backspace toggle the magnet. The different buttons represent different scenes. Click predicted view. If buttons disappear, go to Edit->Clear all Player prefs. 

7. The delay can be changed when the game is not running by clicking the Game Manger object on the left, and changing the delay value in the inspector on the right. 

8. CARV should be getting Unity images with the specified delay, and the reconstruction should be made after slightly moving the camera around the scene.

9. Click show texture in the CARV Map Viewer to view the rendered predicted display. 




## Code Arrangment and Explanation
The root directory contains two folders. `/ArmRobot` contains the Unity code and game scene. The game scene can be found in `/ArmRobot/Assets/Scenes/Office.unity`. This scene has several game objects, such as the robot arm, the objects it interacts with, other scene objects, and objects that handle ROS communication. Changes to the scene can be made using a Unity editor (see pre-requisites). Changes to the C# scripts that the game objects rely can be made on using Visual Studio.

`/CARV` contains the online 3D reconstruction and predictive display implementations. The underlying 3D reconstruction framework is the same as in the [original CARV repository](https://github.com/atlas-jj/ORB-SLAM-free-space-carving), with our predictive display algorithm being implementated in the `/CARV/Modeler` source and header files. The ROS communication is implemented in `/CARV/Examples/ROS/ORB_CARV_Pub/ros_mono.cc`.





