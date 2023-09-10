# unity_learning_PVZ
Start learning unity3D on my own. Sharing my demos and some experiences.



## First Day of Development: 2023.9.10

My learning plan is to find a project and then follow tutorials to learn how to use Unity3D directly. However, there is a downside to this approach. I know almost nothing about Unity3D, so I could encounter countless problems at every step. Progress is relatively slow. Today, it took me nearly three hours to achieve background importing, sunlight creation, and the functionality to generate sunlight randomly. I encountered several main issues:

1. What do the various parameters of the Camera represent?
2. What are the specific usage methods and scenarios for Canvas?
3. Does Text Legacy only serve to display text?
4. How do I add a custom layer priority to a Layer?
5. What is transform.position, and which object's position value does it refer to in the project?
6. This is something I discovered after searching for a bug for half an hour: when you drag a material into Unity3D's SampleScene, it becomes a separate entity from the source file. So, when accessing instances and prefabs in the code, you are referencing the source file. Therefore, if you don't bind the script to the source file of the game object but to an object in the game scene, the code won't be able to access the properties of the game object.

