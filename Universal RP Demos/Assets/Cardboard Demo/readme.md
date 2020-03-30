#

Based on this https://www.youtube.com/watch?v=qZzhXHqXM-g

## Android

+ Following [Google Cardboard: Getting Started with Android](https://developers.google.com/vr/develop/unity/get-started-android), make sure you have the Android development module downloaded for your version of Unity.

+ [Enable developer options and USB debugging](https://developer.android.com/studio/debug/dev-options.html#enable) so that you can upload custom apps to your phone

+ [Setup your Android development environment](https://docs.unity3d.com/Manual/android-sdksetup.html) which includes downloading the Android dev packages via Unity Hub (note that you need to expand the dropdown menu for Android Build Support and include SDK, NDK, and JDK options.

+ Under Player Settings
  + Other Settings -> Rendering -> Graphics APIs -> Delete "Vulkan" from the list
  + If you are using URP/LWRP make sure to change Stereo Rendering Mode to Single Pass in Project Settings -> Player -> XR Settings

## iPhone/iOS

+ Following [Google Cardboard: Getting Started with iOS](https://developers.google.com/vr/develop/unity/get-started-ios), make sure you have the iOS development module downloaded for your version of Unity.

+ [Setup your iOS development environment](https://docs.unity3d.com/Manual/iphone-GettingStarted.html) which includes installing XCode.

## Unity Scene

+ [Download and import the Google VR for Unity .unitypackage](https://github.com/googlevr/gvr-unity-sdk/releases/download/v1.200.1/GoogleVRForUnity_1.200.1.unitypackage)

+ Create a new scene, add a Plane and Cube

+ Rename the Cube to Looking Cube and give it a new red Material

+ Search for GVREditorEmulator in the Project View and add it to the Hierarchy

+ Hit play, you can hold alt and use the mouse to look around as if you were in VR. This emulator is locked to Y position 0, so you'll have to create an Empty Game Object (perhaps call it Camera Rig) and move that to 1.0 on the Y axis, then drag the Main Camera onto it so that it is a Child of Camera Rig. This gives it an offset on the Y axis. Make sure the Main Camera position is set to 0,0,0

+ Search for GVRReticlePointer in the Project View and make it a Child of Main Camera. With the Main Camera still selected, add the GvrPointerPhysicsRaycaster Component to it

+ Search for GVREventSystem in the Project View and drag it into the root of your Scene in the Hierarchy

+ Create a new Script and name it LookingCube.cs, drag it to the Looking Cube in your Scene, add these methods:

```
public class LookingCube : MonoBehaviour
{
    // if you are like me and your headset doesn't have a button
    // one workaround is to "select" by looking at something
    // for some specified amount of time, like over 2 seconds:
    public float LookDurationTrigger = 2.0f;

    // just some  simple public functions to change the color of the cube
    public void StartLooking()
    {
        Debug.Log("turning red");
        // normally we would set the color like this:
        //GetComponent<Renderer>().material.color = Color.red;

        // but using Universal Render Pipeline, the standard shaders work
        // a little differently, so we do this:
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
    }

    public void StopLooking()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
    }

    public void ActivateLooking()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue);

        // bonus: experiment with things like making objects fall when you "tap" them
        Rigidbody gameObjectsRigidBody = gameObject.AddComponent<Rigidbody>();
        gameObjectsRigidBody.mass = 2;
    }
}
```

+ Add a Event Trigger Component to Looking Cube in the Inspector, then add a new Event Type for PointerEnter. Where it says None (Object) in the Event you just created, add the Looking Cube from the Hierarchy.

+ Now from where it says "No Function" you can select Looking Cube -> StartLooking

+ Do the same for Green and Blue: Add a new Event Trigger for PointerExit and assign the StopLooking method to it, then add an Event Trigger for PointerClick and assign the ActivateLooking method to it.

+ Duplicate the Looking Cube a few times, and experiment with its location, size, rotation, and scale

## Build Game

+ Once you are ready to upload to your phone, go to Build Settings and click on Android (or iOS) and hit "Switch Platform"
