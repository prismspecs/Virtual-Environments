##

[Download the .unitypackage file here](https://github.com/googlevr/gvr-unity-sdk/releases/download/v1.200.1/GoogleVRForUnity_1.200.1.unitypackage).

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

## Build Game

+ Once you are ready to upload to your phone, go to Build Settings and click on Android (or iOS) and hit "Switch Platform"
