import CategoryController from "./controllers/category-controller"
import ApiService from "./services/api-service";

//variables
const btnCreateList = document.querySelector("#showCreateList");
const listGroup = document.querySelector('.list-group');
const tabContent = document.querySelector(".tab-content");

//controllers
const categoryController = new CategoryController();

$(function () {
    new ApiService().getTasks();
});


//listeners
//1) categories
btnCreateList.addEventListener("click", categoryController.CreateCategory);
listGroup.addEventListener("click", categoryController.EditCategory);
listGroup.addEventListener("click", categoryController.switchCategory);







    








