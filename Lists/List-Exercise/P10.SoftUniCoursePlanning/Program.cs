using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<string> listOfObjects = arr.ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "course start")
            {
                string[] cmdArgs = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string lessonTitle = cmdArgs[1];

                if (action == "Add")
                {

                    if (!listOfObjects.Contains(lessonTitle))
                    {
                        listOfObjects.Add(lessonTitle);
                    }
                }

                else if (action == "Insert")
                {

                    if (!listOfObjects.Contains(lessonTitle))
                    {
                        int index = int.Parse(cmdArgs[2]);
                        listOfObjects.Insert(index, lessonTitle);
                    }
                }

                else if (action == "Remove")
                {
                    string lessonName = cmdArgs[1];
                    string exercisename = cmdArgs[1] + "-Exercise";
                    listOfObjects.Remove(exercisename);
                    listOfObjects.Remove(lessonTitle);
                }

                else if (action == "Swap")
                {
                    string lessonTitleOne = cmdArgs[1];
                    string lessonTitleTwo = cmdArgs[2];
                    int firstIndex = listOfObjects.FindIndex(element => element.Contains(lessonTitleOne));
                    int secondIndex = listOfObjects.FindIndex(element => element.Contains(lessonTitleTwo));
                    if (firstIndex > secondIndex)
                    {
                        string smallerIndexForSwappingObject = lessonTitleTwo;
                        lessonTitleTwo = lessonTitleOne;
                        lessonTitleOne = smallerIndexForSwappingObject;
                    }

                    SwapLessons(listOfObjects, lessonTitleOne, lessonTitleTwo);
                }


                else if (action == "Exercise")
                {
                    string exerciseLessonName = cmdArgs[1];
                    string exersiceName = cmdArgs[1] + "-Exercise";

                    if (listOfObjects.Contains(exersiceName))
                    {
                        continue;
                    }

                    else if (listOfObjects.Contains(exerciseLessonName))
                    {
                        AddOnlyExerciseAfterTheLesson(listOfObjects, exerciseLessonName);
                    }
                    else
                    {
                        AddLessonAndExercise(listOfObjects, exerciseLessonName);
                    }
                }

            }

            for (int i = 1; i <= listOfObjects.Count; i++)
            {
                Console.WriteLine($"{i}.{listOfObjects[i - 1]}");
            }
        }

        static void SwapLessons(List<string> listOfObjects, string lessonTitleSwapOne, string lessonTitleSwapTwo)
        {
            int lessonTitleOneIndex = -1;
            int lessonTitleTwoIndex = -1;
            bool hasLessonExerciseFirstObject = false;
            bool hasLessonExerciseSecondObject = false;
            int lessonTitleOneExerciseIndex = 0;
            int lessonTitleTwoExerciseIndex = 0;
            string lessonOneExerciseName = string.Empty;
            string lessonTwoExerciseName = string.Empty;

            for (int i = 0; i < listOfObjects.Count; i++)
            {

                if (listOfObjects[i] == lessonTitleSwapOne)
                {
                    lessonTitleOneIndex = i;

                    if (listOfObjects.Count - 1 > i)
                    {

                        if (listOfObjects[i + 1] == listOfObjects[i] + "-Exercise")
                        {
                            hasLessonExerciseFirstObject = true;
                            lessonTitleOneExerciseIndex = i + 1;
                            lessonOneExerciseName = listOfObjects[i + 1];
                        }
                    }
                }

                else if (listOfObjects[i] == lessonTitleSwapTwo)
                {
                    lessonTitleTwoIndex = i;

                    if (listOfObjects.Count - 1 > i)
                    {
                        if (listOfObjects[i + 1] == listOfObjects[i] + "-Exercise")
                        {
                            hasLessonExerciseSecondObject = true;
                            lessonTitleTwoExerciseIndex = i + 1;
                            lessonTwoExerciseName = listOfObjects[i + 1];
                        }
                    }
                }
            }

            if (lessonTitleOneIndex == -1 || lessonTitleTwoIndex == -1)
            {
                return;
            }

            else if (hasLessonExerciseFirstObject || hasLessonExerciseSecondObject)
            {
                SwapLessonsWithExercises(listOfObjects, lessonTitleOneExerciseIndex, lessonTitleTwoExerciseIndex,
                                         hasLessonExerciseFirstObject, hasLessonExerciseSecondObject,
                                         lessonTitleSwapOne, lessonTitleSwapTwo,
                                         lessonOneExerciseName, lessonTwoExerciseName,
                                         lessonTitleOneIndex, lessonTitleTwoIndex);
            }

            else
            {
                listOfObjects.Remove(lessonTitleSwapOne);
                listOfObjects.Insert(lessonTitleTwoIndex, lessonTitleSwapOne);

                listOfObjects.Remove(lessonTitleSwapTwo);
                listOfObjects.Insert(lessonTitleOneIndex, lessonTitleSwapTwo);
            }
        }

        static void SwapLessonsWithExercises(List<string> listOfObjects, int lessonTitleOneExerciseIndex, int lessonTitleTwoExerciseIndex,
                                             bool hasLessonExerciseFirstObject, bool hasLessonExerciseSecondObject,
                                             string lessonTitleSwapOne, string lessonTitleSwapTwo,
                                             string lessonOneExerciseName, string lessonTwoExerciseName,
                                             int lessonTitleOneIndex, int lessonTitleTwoIndex)
        {
            if (hasLessonExerciseFirstObject && hasLessonExerciseSecondObject)
            {
                listOfObjects.Insert(lessonTitleTwoIndex, lessonTitleSwapTwo);
                listOfObjects.Insert(lessonTitleTwoIndex + 1, lessonTwoExerciseName);
                listOfObjects.RemoveAt(lessonTitleTwoIndex + 2);
                listOfObjects.RemoveAt(lessonTitleTwoIndex + 2);

                listOfObjects.Insert(lessonTitleOneIndex, lessonTitleSwapOne);
                listOfObjects.Insert(lessonTitleOneIndex + 1, lessonOneExerciseName);
                listOfObjects.RemoveAt(lessonTitleOneIndex + 2);
                listOfObjects.RemoveAt(lessonTitleOneIndex + 2);
            }

            else
            {
                if (hasLessonExerciseFirstObject)
                {
                    listOfObjects.Insert(lessonTitleTwoIndex, lessonTitleSwapOne);
                    listOfObjects.Insert(lessonTitleTwoIndex + 1, lessonOneExerciseName);
                    listOfObjects.RemoveAt(lessonTitleOneIndex);
                    listOfObjects.RemoveAt(lessonTitleOneIndex);

                    listOfObjects.Remove(lessonTitleSwapTwo);
                    listOfObjects.Insert(lessonTitleOneIndex, lessonTitleSwapTwo);
                }


                else if (hasLessonExerciseSecondObject)
                {
                    listOfObjects.Insert(lessonTitleTwoIndex, lessonTitleSwapOne);
                    listOfObjects.RemoveAt(lessonTitleOneIndex);

                    listOfObjects.Remove(lessonTitleSwapTwo);
                    listOfObjects.Remove(lessonTwoExerciseName);
                    listOfObjects.Insert(lessonTitleOneIndex, lessonTitleSwapTwo);
                    listOfObjects.Insert(lessonTitleOneIndex + 1, lessonTwoExerciseName);
                }
            }
        }
        static void AddOnlyExerciseAfterTheLesson(List<string> listOfObjects, string exerciseLessonName)
        {
            string exerciseName = exerciseLessonName + "-Exercise";

            for (int i = 0; i < listOfObjects.Count; i++)
            {
                if (listOfObjects[i] == exerciseLessonName)
                {
                    listOfObjects.Insert(i + 1, exerciseName);
                    break;
                }
            }
        }

        static void AddLessonAndExercise(List<string> listOfObjects, string exerciseLessonName)
        {
            string exerciseName = exerciseLessonName + "-Exercise";

            listOfObjects.Add(exerciseLessonName);
            listOfObjects.Add(exerciseName);
        }
    }
}
