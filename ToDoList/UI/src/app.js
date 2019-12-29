import CategoryController from "./controllers/category-controller"
import ApiService from "./services/api-service";
import TaskController from "./controllers/task-controller";

//variables
const btnCreateList = document.querySelector("#showCreateList");
const listGroup = document.querySelector('.list-group');
const tabContent = document.querySelector(".tab-content");
const createTaskForm = document.forms.namedItem("AddTask");

//controllers
const categoryController = new CategoryController();
const taskController = new TaskController();

// load data
$(function () {
    new ApiService().getCategories();
});


//listeners
//1) categories
btnCreateList.addEventListener("click", categoryController.CreateCategory);
listGroup.addEventListener("click", categoryController.EditCategory);
listGroup.addEventListener("click", categoryController.switchCategory);



//tasks

createTaskForm.addEventListener("submit", (e) => {
    e.preventDefault();

    taskController.createTask();
})









    








