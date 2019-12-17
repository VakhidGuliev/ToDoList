import CategoryController from "./controllers/category-controller"

//variables
const btnCreateList = document.querySelector("#showCreateList");
const listGroup = document.querySelector('.list-group');
const tabContent = document.querySelector(".tab-content");

//controllers
const сategoryController = new CategoryController();



//listeners
btnCreateList.addEventListener("click", сategoryController.CreateCategory);
listGroup.addEventListener("click", сategoryController.EditCategory);







    








