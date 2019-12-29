/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./UI/src/app.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./UI/src/app.js":
/*!***********************!*\
  !*** ./UI/src/app.js ***!
  \***********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _controllers_category_controller__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./controllers/category-controller */ "./UI/src/controllers/category-controller.js");
/* harmony import */ var _services_api_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./services/api-service */ "./UI/src/services/api-service.js");
/* harmony import */ var _controllers_task_controller__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./controllers/task-controller */ "./UI/src/controllers/task-controller.js");




//variables
const btnCreateList = document.querySelector("#showCreateList");
const listGroup = document.querySelector('.list-group');
const tabContent = document.querySelector(".tab-content");
const createTaskForm = document.forms.namedItem("AddTask");

//controllers
const categoryController = new _controllers_category_controller__WEBPACK_IMPORTED_MODULE_0__["default"]();
const taskController = new _controllers_task_controller__WEBPACK_IMPORTED_MODULE_2__["default"]();

// load data
$(function () {
    new _services_api_service__WEBPACK_IMPORTED_MODULE_1__["default"]().getCategories();
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









    










/***/ }),

/***/ "./UI/src/controllers/category-controller.js":
/*!***************************************************!*\
  !*** ./UI/src/controllers/category-controller.js ***!
  \***************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _services_api_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../services/api-service */ "./UI/src/services/api-service.js");
/* harmony import */ var _services_modal_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/modal-service */ "./UI/src/services/modal-service.js");
﻿


class CategoryController {
    constructor() {}

    //create
    CreateCategory() {

        new _services_modal_service__WEBPACK_IMPORTED_MODULE_1__["default"]().CreateCategory();

        const btnCreate = document.querySelector("button.create");

        if (!btnCreate.classList.contains("create")) {
            return;
        }

        btnCreate.addEventListener("click", (e) => {
            e.preventDefault();

            const categoryName = $("input[name='Name']").val();

            new _services_api_service__WEBPACK_IMPORTED_MODULE_0__["default"]().createCategory(categoryName);
        });
    }

    //delete,edit
    EditCategory(e) {

        new _services_modal_service__WEBPACK_IMPORTED_MODULE_1__["default"]().EditCategory(e);

        let link = e.target;

        if (!link.classList.contains("fa-edit")) {
            return;
        }

        let btnEditSave = document.querySelector("button.save");
        let btnDelete = document.querySelector("button.btn-delete");


        btnDelete.addEventListener("click", (e) => {
            e.preventDefault();

            const id = $(".list-group-item-action.active").attr("data-id");

            new _services_api_service__WEBPACK_IMPORTED_MODULE_0__["default"]().deleteCategory(id);
        })
        btnEditSave.addEventListener("click", (e) => {

            e.preventDefault();

            
            const categoryName = $("input[name='Name']").val();
            const id = $(".list-group-item-action.active").attr("data-id");
            
            new _services_api_service__WEBPACK_IMPORTED_MODULE_0__["default"]().editCategory(id,categoryName);
        });

    }
    
    //switch
    switchCategory(e){
        new _services_modal_service__WEBPACK_IMPORTED_MODULE_1__["default"]().showTab(e)
    }
}

/* harmony default export */ __webpack_exports__["default"] = (CategoryController);

/***/ }),

/***/ "./UI/src/controllers/task-controller.js":
/*!***********************************************!*\
  !*** ./UI/src/controllers/task-controller.js ***!
  \***********************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _services_api_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../services/api-service */ "./UI/src/services/api-service.js");


class TaskController {
    constructor() {}

    editTask() {}

    deleteTask() {}

    createTask() {

                    

                const taskData = {
                    'Name': $("form[name='AddTask']").find("input[name='Name']").val(),
                    'Description': "",
                    'CategoryId': $(".tab-content .tab-pane.active").attr("data-id")
                };

                new _services_api_service__WEBPACK_IMPORTED_MODULE_0__["default"]().createTask(taskData)
        }
}

/* harmony default export */ __webpack_exports__["default"] = (TaskController);

/***/ }),

/***/ "./UI/src/services/api-service.js":
/*!****************************************!*\
  !*** ./UI/src/services/api-service.js ***!
  \****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _modal_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./modal-service */ "./UI/src/services/modal-service.js");
/* harmony import */ var _render_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./render-service */ "./UI/src/services/render-service.js");
/* harmony import */ var _transform_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./transform-service */ "./UI/src/services/transform-service.js");
﻿



class ApiService {
    createCategory(categoryName) {
        $.ajax({
            url: '/Home/CreateCategory',
            type: 'POST',
            data: { Name: categoryName },
            dataType: 'html',
            success: function () {
                $(".invalid-feedback").hide();
                $(".valid-feedback").show();
                $(".valid-feedback").html(`Category ${categoryName} successfully created`);
                new _render_service__WEBPACK_IMPORTED_MODULE_1__["default"]().renderCategory();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $(".valid-feedback").hide();
                $(".invalid-feedback").show();
                $(".invalid-feedback").html(xhr.responseText)
            }
        });
    }
    editCategory(id,newData) {
        $.ajax({
            url: '/Home/EditCategory',
            type: 'PUT',
            data: { Id: id, Name: newData },
            dataType: 'html',
            success: function (data) {

                const newData = JSON.parse(data);
                const newName = newData.name;
                const Tab = new _modal_service__WEBPACK_IMPORTED_MODULE_0__["default"]().Tabs();

                Tab.listContainer.querySelector(`a[data-id='${id}']`).querySelector(".listName").innerHTML = newName;
                Tab.listContainer.querySelector(`a[data-id='${id}']`).setAttribute(`data-name`, `${newName}`);
                Tab.tabContainer.querySelector(`.tab-pane[data-id='${id}']`).setAttribute(`data-name`, `${newName}`);

                document.querySelector(".categoriesName").innerHTML = newName;

                $('#ListModal').modal('hide');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr)
            }
        });
    }
    deleteCategory(id){
        $.ajax({
            url: '/Home/DeleteCategory',
            type: 'DELETE',
            data: { Id: id},
            dataType: 'html',
            success: function () {
                const Tab = new _modal_service__WEBPACK_IMPORTED_MODULE_0__["default"]().Tabs();
                
                Tab.listContainer.querySelector(`a[data-id='${id}']`).remove();
                Tab.tabContainer.querySelector(`.tab-pane[data-id='${id}']`).remove();

                document.querySelector(".categoriesName").innerHTML = "";


                $("#myList a:first-child").addClass("active")
                $(".tab-content .tab-pane:first-child").addClass("active");

                const activeName = $("#myList a:first-child").attr("data-name");

                document.querySelector(".categoriesName").innerHTML = activeName;
                
                $('#ListModal').modal('hide');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr)
            }
        });
    }
    getCategories() {
        $.ajax({
            url: '/Home/CategoryList',
            type: 'GET',
            success: function (data) {
                
                
                const Tab = new _modal_service__WEBPACK_IMPORTED_MODULE_0__["default"]().Tabs();
                const TaskObject = data;
                
                
                const promise = Object(_transform_service__WEBPACK_IMPORTED_MODULE_2__["fbTransformToArray"])(TaskObject);

                promise.then(function (arr) {
                    let objectKeys = Object.keys(TaskObject);
                    

                    //Update database
                    document.querySelector("#myList").innerHTML = "";
                    document.querySelector(".tab-content").innerHTML = "";

                    objectKeys.forEach((value, index, array) => {
                        array = arr;
                        
                        const objs = array[value];
                        index = objs.id;

                        Tab.listContainer.insertAdjacentHTML("beforeend", Tab.renderLists(objs.name, index, 0));
                        Tab.tabContainer.insertAdjacentHTML("beforeend", Tab.renderTabs(objs.name, index));

                        Tab.listContainer.querySelectorAll("a").forEach(value => value.classList.remove("active"));
                        Tab.tabContainer.querySelectorAll(".tab-pane").forEach(value => value.classList.remove("active"));

                        document.querySelector("#myList a:first-child").classList.add("active");
                        document.querySelector(".tab-content .tab-pane:first-child").classList.add("active");

                        document.querySelector(".categoriesName").innerHTML = array[0].name;
                    });
                }).catch(e => console.log(e.message));

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.responseText)
            }
        });
    }
    
    getTasks() {
        $.ajax({
            url: '/Home/TaskList',
            type: 'GET',
            success: function (data) {
                console.log(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.responseText)
            }
        });
    }
    
    createTask(data){
        $.ajax({
            url: '/Home/CreateTask',
            type: 'POST',
            data: data,
            success: function () {
               console.log("задача создана");
            },
            error: function (xhr, ajaxOptions, thrownError) {
               console.log(xhr.responseText)
            }
        });
    }
}

/* harmony default export */ __webpack_exports__["default"] = (ApiService);

/***/ }),

/***/ "./UI/src/services/modal-service.js":
/*!******************************************!*\
  !*** ./UI/src/services/modal-service.js ***!
  \******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
class ModalService {

    constructor() {
        this.listForm = document.querySelector("#ListForm");
        this.listName = document.querySelector("input.listName");
        this.modalButtons = document.querySelector(".modal-footer .buttons");
        this.modalTitle = document.querySelector("#ListModalTitle");
    }


    CreateCategory() {

        //open modal
        $("#ListModal").modal("show");

        this.modalButtons.innerHTML = "";

        //buttons template
        let buttons = `<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                       <button type="submit" class="btn btn-primary create">Save</button>`;
        this.modalButtons.insertAdjacentHTML("afterbegin", buttons);

        //modal options
        this.listForm.name = "createListForm";
        this.modalTitle.innerHTML = "Create New List";
        this.listName.id = "createList";
        this.listName.setAttribute("value", "");
    }
    EditCategory(e) {

        let link = e.target;
        let currentList = link.parentElement.parentElement;
        let currentListName = currentList.getAttribute("data-name");


        if (!link.classList.contains("fa-edit")) {
            return;
        }

        //open modal
        $("#ListModal").modal("show");

        this.modalButtons.innerHTML = "";

        //buttons template
        let buttons = `<button type="submit" style="position:absolute;left:30px;" class="btn btn-danger btn-delete">Delete</button>
                       <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                       <button type="submit" class="btn btn-primary save">Save</button>`;
        this.modalButtons.insertAdjacentHTML("afterbegin", buttons);

        //modal options
        this.listForm.name = "editListForm";
        this.modalTitle.innerHTML = "Edit List";
        this.listName.id = "editList";
        this.listName.setAttribute("value", currentListName);
    }


    Tabs() {
        return {
            listContainer: document.querySelector("#myList"),
            tabContainer: document.querySelector(".tab-content"),
            renderLists: function (list, index, array) {
                return `<a class="list-group-item list-group-item-action" data-name="${list}" data-id="${index}" role="tab">
                                <span class="listName"><i class="fa fa-list-ul"></i>${list}</span>
                                <span class="listCount badge badge-primary" title="Task count">${array}</span>
                                <span class="editList" title="List options"><i class="fa fa-edit"></i></span>
                            </a>`
            },
            renderTabs: function (tab, index) {
                return `<div class="tab-pane"  data-name="${tab}" data-id="${index}" role="tabpanel"></div>`
            }
        };
    }
    showTab (e) {
        let link = e.target;

        if (!link.classList.contains('list-group-item')) {
            return;
        }

        let linkName = link.dataset.name;
        let listSearch = document.querySelector(".tab-content .searchList");

        document.querySelectorAll('.tab-pane, .list-group-item').forEach(el => {
            el.classList.remove("active");
        });

        document.querySelectorAll(".tab-pane").forEach(value => value.classList.remove("hide"));
        document.querySelectorAll(".tab-pane.active").forEach(value => value.classList.add("show"));

        if (listSearch) {
            listSearch.remove();
        }


        link.classList.add("active");
        document.querySelector(`.tab-pane[data-name='${linkName}']`).classList.add("active");
        document.querySelector(".categoriesName").innerHTML = linkName;
        document.querySelector(".AddTask").style.display = "block";
    }
}

/* harmony default export */ __webpack_exports__["default"] = (ModalService);

/***/ }),

/***/ "./UI/src/services/render-service.js":
/*!*******************************************!*\
  !*** ./UI/src/services/render-service.js ***!
  \*******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _modal_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./modal-service */ "./UI/src/services/modal-service.js");


class RenderService {
    constructor(){}
    
    renderCategory(){
        let category = {
            categoryName: document.querySelector("#createList").value.toString().trim(),
        };

        const listForm = document.querySelector("#ListForm");
        let categoryName = document.querySelector("#createList");
        let tabNameLength = document.querySelector(`.tab-content .tab-pane[id="${category.categoryName}"]`);
        let listLength = document.querySelectorAll("#myList a").length;
        const lastId = parseInt($(".list-group a:last-child").attr("data-id"));
        const newId = (lastId + 1).toString();


        if (category.categoryName && isNaN(category.categoryName) && tabNameLength === null) {

            let Tab = new _modal_service__WEBPACK_IMPORTED_MODULE_0__["default"]().Tabs();

            // render
            Tab.listContainer.insertAdjacentHTML("beforeend", Tab.renderLists(category.categoryName, newId, 0));
            Tab.tabContainer.insertAdjacentHTML("beforeend", Tab.renderTabs(category.categoryName, newId));

            //delete active class
            Tab.listContainer.querySelectorAll("a").forEach(value => value.classList.remove("active"));
            Tab.tabContainer.querySelectorAll(".tab-pane").forEach(value => value.classList.remove("active"));

            //add active class created category
            Tab.listContainer.querySelector(`a[data-name=${category.categoryName}]`).classList.add("active");
            Tab.tabContainer.querySelector(`.tab-pane[data-name=${category.categoryName}]`).classList.add("active");

            document.querySelector(".categoriesName").innerHTML = category.categoryName;

            // valid categoryName
            categoryName.classList.remove("is-invalid");
            categoryName.classList.add("is-valid");

            listForm.reset();

            $(".valid-feedback").html("");
            $(".invalid-feedback").html("");

            $('#ListModal').modal('hide');
        } else {
            categoryName.classList.add("is-invalid");
            return false;
        }
    }
}

/* harmony default export */ __webpack_exports__["default"] = (RenderService);

/***/ }),

/***/ "./UI/src/services/transform-service.js":
/*!**********************************************!*\
  !*** ./UI/src/services/transform-service.js ***!
  \**********************************************/
/*! exports provided: fbTransformToArray */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fbTransformToArray", function() { return fbTransformToArray; });
// transform firebase data to object=>
async function fbTransformToArray(fbData) {
    return Object.keys(fbData).map(function (value) {
        const item = fbData[value];

        item.tasksCount = Object.keys(item).length-2;
        return item;
    })
}



/***/ })

/******/ });
//# sourceMappingURL=app.bundle.js.map