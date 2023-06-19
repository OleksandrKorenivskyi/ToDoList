export const getCategoriesQuery = `
{ 
  categories { 
    list { 
      id 
      name 
    } 
  } 
}`;

export const getTasksQuery = `
{
   tasks {
      list {
         id 
         description 
         dueDate 
         completed 
         categoryId
        }
      }
}`;

export const deleteTaskMutation = `
mutation($id: ID!) { 
  tasks { 
    delete(id: $id) 
  } 
}`;

export const toggleCompletionTaskMutation = `
mutation($id: ID!) {
   tasks {
      toggleCompletion(id: $id) 
    } 
  }`;

export const saveTaskMutation = `
mutation($input: TaskInput!) {
   tasks { 
     save(input: $input)
    } 
  }`;
  
export const changeDataStorageMutation = `
mutation {
   configuration {
      changeDataStorage(storageType: DATABASE) 
    } 
  }`;