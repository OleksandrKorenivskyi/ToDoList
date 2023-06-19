const createCategory = (id: string, name: string) => {
  return { id, name };
};

const createTask = (id: string, categoryName: string, description: string, dueDate: string, isCompleted: boolean) => {
  return { id, categoryName, description, dueDate, isCompleted };
};

const createStorageType = (name: string, value: string) => {
  return {name, value};
};

export const categories = [
  createCategory('1', 'Homework'),
  createCategory('2', 'Job'),
  createCategory('3', 'Sport'),
];

export const tasks = [
  createTask('1', 'Job', 'Test description 1', '11/11/2022 8:00 AM', false),
  createTask('2', 'Job', 'Test description 2', '11/11/2022 8:00 AM', false),
  createTask('3', 'Job', 'Test description 3', '11/11/2022 8:00 AM', false),
  createTask('4', 'Job', 'Test description 4', '11/11/2022 8:00 AM', false),
  createTask('5', 'Job', 'Test description 5', '11/11/2022 8:00 AM', false),
  createTask('6', 'Job', 'Test description 6', '11/11/2022 8:00 AM', false),
];

export const storageTypes = [
  createStorageType('XLM file', 'XmlFile'),
  createStorageType('Database', 'Database'),
];