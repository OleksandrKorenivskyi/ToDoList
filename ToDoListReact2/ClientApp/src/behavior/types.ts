export type StorageType = {
  value: string;
  name: string;
}

export type Category = {
  id: string;
  name: string;
}

export type Task = {
  id: string;
  isCompleted: boolean;
  description: string;
  categoryName: string;
  dueDate: Date | null;
}

export type TaskInput = {
  description: string | null;
  dueDate: string | null;
  categoryId: string | null;
}