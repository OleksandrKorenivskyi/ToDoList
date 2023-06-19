import { v4 as uuidv4 } from 'uuid';
import { TaskInput, Task } from './types';
import { categories } from '../data';

export function createTask(input: TaskInput): Task {
  const categoryId = input.categoryId ?? categories[0].id;
  return {
    id: uuidv4(),
    description: input.description ?? '',
    dueDate: input.dueDate ? new Date(input.dueDate) : null,
    // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
    categoryName: categories.find(c => c.id === categoryId)!.name,
    isCompleted: false,
  };
}

export function sortTasks(tasks: Task[]): Task[] {

  function compareTasks(taskA: Task, taskB: Task) {
    let taskAWeight = 0;
    let taskBWeight = 0;

    if (taskA.isCompleted && !taskB.isCompleted)
      taskAWeight += 2;
    if (taskB.isCompleted && !taskA.isCompleted)
      taskBWeight += 2;
    if (taskA.dueDate == null)
      taskAWeight++;
    if (taskB.dueDate == null)
      taskBWeight++;
    if (taskA.dueDate != null && taskB.dueDate != null) {
      if (taskA.dueDate > taskB.dueDate)
        taskAWeight++;
      if (taskB.dueDate > taskA.dueDate)
        taskBWeight++;
    }

    return taskAWeight === taskBWeight ? 0 : taskAWeight > taskBWeight ? 1 : -1;
  }

  return tasks.sort(compareTasks);
}
