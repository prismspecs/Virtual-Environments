# Mixamo to Unity

This requires
1. A humanoid model in a T-Pose and export as FBX
  + Quick note on Mirror mode in Blender and [a reference for the same in Maya](https://knowledge.autodesk.com/support/maya/learn-explore/caas/CloudHelp/cloudhelp/2018/ENU/Maya-Modeling/files/GUID-FAD058BA-26C9-4914-B26E-1E4D0701D845-htm.html)
2. Create a [Mixamo](https://www.mixamo.com) account
  + Note that you cannot use a .edu address
3. Upload your character and drag the body part pins to the model
  + Note that you should likely select the no fingers option
  + If your upload does not work, try adding more geometry to your mesh around the elbows and knees
4. Click through a few animations
5. Find a Walking animation and be sure to check "In Place"
6. Click download and set format to FBX for Unity
7. Drag the FBX file into your Unity project
8. Create a plane and drag the FBX into your scene
9. Create an Animator Controller
10. Drag the Walking animation into the Animator window
11. Drag the Animator Controller onto the "Controller" property of your humanoid in the scene
12. Play, and note that the animation doesn't loop
13. Select the Walking animation file in the Project view and click "Edit" in the inspector
14. Set the Loop Time option to true and apply the changes
15. Download another animation, this time Idle
  + Use FBX for Unity and select Without Skin
16. Drag it into your project, expand the prefab and drag the Idle animation clip into your Animator
17. Once again Edit the animation and select Loop Time
18. In the Animator window, right click the Idle Animation and set it as the default
19. Right click the Idle clip and create a transition to the Walking clip
20. Create a Parameter of type float in the Animator and call it "speed"
21. Click on the transition from Idle to Walking and set a condition for Speed Greater than 0.1
22. Create a transition from Walking to Idle with a condition of Speed Less than 0.1
