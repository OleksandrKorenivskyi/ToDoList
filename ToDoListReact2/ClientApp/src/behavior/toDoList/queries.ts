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
mutation { 
  tasks { 
    delete(id: "_____") 
  } 
}`;
export const toggleCompletionTaskMutation = `
mutation {
   tasks {
      toggleCompletion(id: "_____") 
    } 
  }`;
export const saveTaskMutation = `
mutation {
   tasks { 
     save(input: { description: "string", completed: true }) 
    } 
  }`;
export const changeDataStorageMutation = `mutation {
   configuration {
      changeDataStorage(storageType: DATABASE) 
    } 
  }`;