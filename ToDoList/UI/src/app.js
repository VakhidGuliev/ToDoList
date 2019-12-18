import CategoryController from "./controllers/category-controller"
import ApiService from "./services/api-service";

//variables
const btnCreateList = document.querySelector("#showCreateList");
const listGroup = document.querySelector('.list-group');
const tabContent = document.querySelector(".tab-content");

//controllers
const сategoryController = new CategoryController();

$(function () {
    new ApiService().getTasks();
});


//listeners
btnCreateList.addEventListener("click", сategoryController.CreateCategory);
listGroup.addEventListener("click", сategoryController.EditCategory);







    








