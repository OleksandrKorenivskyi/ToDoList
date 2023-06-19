export enum StorageType {
  Database = 'Database',
  XmlFile = 'XmlFile',
}

export type Category = {
  id: string;
  name: string;
}

export type Task = {
  id: string;
  completed: boolean;
  description: string;
  categoryName: string;
  dueDate: string | null;
}

export type TaskInput = {
  description: string | null;
  dueDate: string | null;
  categoryId: string | null;
}

