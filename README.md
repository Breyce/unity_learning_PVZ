# unity_learning_PVZ
Start learning unity3D on my own. Sharing my demos and some experiences.



## Development Day 1: 2023.9.10

My learning plan is to find a project and then follow tutorials to learn how to use Unity3D directly. However, there is a downside to this approach. I know almost nothing about Unity3D, so I could encounter countless problems at every step. Progress is relatively slow. Today, it took me nearly three hours to achieve background importing, sunlight creation, and the functionality to generate sunlight randomly. I encountered several main issues:

1. What do the various parameters of the Camera represent?
   - https://blog.csdn.net/weixin_43147385/article/details/124234741
2. What are the specific usage methods and scenarios for Canvas?
3. Does Text Legacy only serve to display text?
4. How do I add a custom layer priority to a Layer?
5. What is transform.position, and which object's position value does it refer to in the project?
6. This is something I discovered after searching for a bug for half an hour: when you drag a material into Unity3D's SampleScene, it becomes a separate entity from the source file. So, when accessing instances and prefabs in the code, you are referencing the source file. Therefore, if you don't bind the script to the source file of the game object but to an object in the game scene, the code won't be able to access the properties of the game object.

## Development Day 2：2023.9.11

After paying attention to the issues from yesterday, today's progress is much smoother. I've learned some methods for using Animation in Unity3D, although it took some effort to get the hang of it. I encountered the following main issues:

1. What kind of data type is **IEnumerator** in C#?

2. The biggest time-waster today was when I attached an event to one frame of the animation. This event kept triggering twice. It wasn't until later that I realized when I set "Use Transitions" to "Yes," it would play both animations again at the end of the first animation and the start of the second animation, causing that one frame to be played twice and triggering the event twice. It's quite puzzling.

## Development Day 3: 2023.10.4

Because I've been busy with the graduate school application process for a long time, I haven't continued working on PVZ production for quite a while. When I returned to the project, I realized that I needed to reacquaint myself with some things. Today, the most challenging issue that troubled me was the Pea Shooter part. When I was only creating examples before, I found that the Pea Shooter could shoot peas from the correct position, and I thought I had succeeded. However, today I suddenly realized that the peas were always being shot from the same world coordinates, regardless of how the Pea Shooter moved. After searching for a while, I discovered that my peas weren't getting the FirePoint game object when they were generated. It turned out that I didn't bind FirePoint and PeaShooter together—I only made PeaShooter a prefab and didn't make FirePoint, this child object, a prefab as well.

Today, I delved into the following three topics.

1. transform.Find():https://blog.csdn.net/weixin_42935398/article/details/102729167
2. Instantiate:https://blog.csdn.net/weixin_43913272/article/details/90246161
3. Open console: https://docs.unity.cn/cn/2021.2/Manual/Console.html

## Development Day 4: 2023.10.12

During the past eight days, I was busy preparing for a final presentation. Today, I finally had some free time and spent about 5 hours to achieve the confrontation between plants and zombies. The main reason was that, for some reason, the Y-axis of the FirePoint was locked, and I hadn't saved my progress earlier, so I had to start over. However, this had its advantages as well. I now have a clearer understanding of the entire combat logic and how to use the characters. I didn't encounter any new challenging concepts today, or perhaps I did, but I might have overlooked them, given that my solution was somewhat brute force: starting over.

## Development Day 5: 2023.10.13

On the fifth day of development, I found that I was becoming proficient in many aspects of Unity. On the first day, it took me two to three hours just to tinker with a prefab, but today, I can recreate a series of game entities in just half an hour. I spent four hours developing today, and both my programming and debugging approaches have become smoother. My understanding of Unity's internal components is also deepening gradually. I didn't encounter any major issues today and managed to fix some minor bugs. However, there's still an issue with the sunflower: it can generate the sun correctly in some parts of the scene but not in others, which is quite strange.

However, there are also some lingering issues from the past, such as coroutines.

## Development Day 6: 2023.10.14

Today was the first time I encountered a bug within Unity itself. The engine couldn't locate one of my game entities. After examining the logic and code for about half an hour, I felt that the issue was with the engine itself. So, I restarted the engine and successfully found it. It felt quite magical because I had a sense of touching some of Unity's underlying compilation and execution logic, even though I didn't see the source code, but I could make some educated guesses. I didn't encounter any new challenges in terms of knowledge today, but I did learn something about audio controls and camera controls, which was today's takeaway.

## Development Day 7: 2023.10.15

Plants vs. Zombies is over today! I only made a very, very basic version, and there are even some minor bugs, but that's okay. My goal was simply to learn Unity-related knowledge, and this was just a starting point. I didn't delve into all the details of the code logic (of course, during the production, I also carefully adjusted all the parameters to make it look better).

Looking back on these days of development, there were many things that impacted progress in between. However, upon careful reflection, I realized that the real transformation began on the fourth day. It was on that day that I no longer found myself completely lost when searching for bugs. My familiarity with the logic of attaching scripts to entities within the game engine and my knowledge of C# and object-oriented programming allowed me to gradually study their content by analyzing both the code logic and Unity's parsing logic. It was a genuine sense of achievement. By the last day, when I was searching for bugs, I could confidently say, "It's the engine that has a bug; let's restart it," and I would find the solution.

Next, I believe what I want to do is create various types of games, explore different scenarios and settings. I hope everything goes smoothly.
