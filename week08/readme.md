# Week 8 (3/10 & 3/12)

## Tuesday & Wednesday: Twine Projects

+ Upcoming Assignments:
  + No in-person assignments for the week after Spring Break (remote class via Zoom!)
  + It is likely that classes will not meet in person for the remainder of the semester. We will hold classes remotely.
  + VR Project (due Weds April 8)
    + Group 1: Connor, Milena, Yuen
    + Group 2: Chloe, Chang, My
    + Group 3: Daniel, Iann, Ava
    + Group 4: Alexander, Nicky, Ethan
    + Each group should have a producer to keep everyone to tasks. Each group should also have a meeting facilitator (separate from the producer) to streamline meetings. Each group should also have a designated note-taker (again, separate from other roles) for meetings.
    + We recommend Notion as an organizational tool. It has a task board, communication and planning functionality, and more.

## Thursday: Intro to VR

+ [Download the Zoom recording](https://NewSchool.zoom.us/rec/share/x-JsHpzZ-WlLTK_w6B77YKs9T6i5eaa82nJNr6ZZmkpUuKnw4OvueUsx7oW3Fbf2?startTime=1584029884000)

+ [Hito Steyerl - Bubble Vision](https://www.youtube.com/watch?v=boMbdtu2rLE)
  + A critical/historical view on Virtual Reality

## Getting Started

+ Install Unity 2019.3.5f1
+ After creating the project be sure to drop the .gitignore file in your working director (in the root director of this repo)
+ [Download the Oculus Rift setup files](https://www.oculus.com/setup/)
+ [Read this guide for full instructions](https://circuitstream.com/blog/oculus-unity-setup/)
+ If you only see output on the left eye, change the Stereo Rendering Mode from Multi Pass to Single Pass in the Player settings under XR Settings it will render to both eyes

+ Quick setup (installing and downloading will take a long time)
  + Attach the Oculus Rift and install all requisite software
  + New Project using Unity 2019.3.3f1
  + Use Universal Project Template
  + File -> Build Settings -> Player Settings -> XR Settings -> Check Virtual Reality Supported
  + Install "Oculus Integration" from the Asset Store
  + It may prompt you to download and install newer versions of VR related software, confirm and allow it to restart Unity if so
  + Because we are using the new Universal Render Pipeline we need to update our materials: Edit -> Render Pipeline -> Universal Render Pipeline -> Upgrade Materials...
  + Create a new scene
  + Delete the Main Camera
  + Drag Oculus -> VR -> Prefabs -> OVRCameraRig prefab into your scene
  + Select the OVRCameraRig in your scene hierarchy. Set Tracking Origin Type on the OVR Manager to Floor Level
  + Drag Oculus -> Avatar -> Content -> Prefabs -> OVRPlayerController into your scene
  + Create a Sphere and rename it to Input Test RIGHT (it will be pinned to the right hand controller) and scale it down to .1 on all axes
  + Attach it as a child to OVRPlayerContoller -> OVRCameraRig -> RightHandAnchor
  + Create a Cube we can use to test interaction

Experiment 1:
+ Give both the Cube and the Input Test RIGHT objects RigidBodies, but make sure to disable Gravity and Enable Is Kinematic on the Input Test RIGHT object. You should be able to push the cube around.

Experiment 2:
+ Disable the Input Test RIGHT object
+ Add the OVRAvatar Prefab as a child to your OVRPlayerController -> OVRCameraRig -> TrackingSpace
+ Add OVR Grabber scripts to Left and Right Hand Anchors
+ Add Sphere Colliders to both as well, with Is Trigger enabled and a radius of .05
+ Select LeftHandAnchor and drag the LeftHandAnchor from the hierarchy to the Grip Transform property of the OVR Grabber script
+ Increase the Grab Volumes to 1 and drag the LeftHandAnchor to Element 0
+ Select L Touch for Controller
+ Do the same for RightHandAnchor (using right hand properties instead)
+ Add a RigidBody (experiment w enabling/disabling Gravity) and a OVR Grabbable script to the Cube object in your scene
+ You should be able to manipulate the object
