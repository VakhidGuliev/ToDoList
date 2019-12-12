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
/* harmony import */ var _controllers_tab_controller__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./controllers/tab-controller */ "./UI/src/controllers/tab-controller.js");


//variables
const btnShowCreateList = document.querySelector("#showCreateList");

//controllers
const tabController = new _controllers_tab_controller__WEBPACK_IMPORTED_MODULE_0__["default"]();



//listeners
btnShowCreateList.addEventListener("click", tabController.showCreateListModal);







    










/***/ }),

/***/ "./UI/src/controllers/tab-controller.js":
/*!**********************************************!*\
  !*** ./UI/src/controllers/tab-controller.js ***!
  \**********************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _services_api_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../services/api-service */ "./UI/src/services/api-service.js");
﻿

class TabController {
    constructor() {

    }

    showCreateListModal() {

        const listForm = document.querySelector("#ListForm");

        $("#ListModal").modal("show");

        document.querySelector(".modal-footer .buttons").innerHTML = "";

        let buttons = `<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                       <button type="submit" class="btn btn-primary create">Save</button>`;
        document.querySelector(".modal-footer .buttons").insertAdjacentHTML("afterbegin", buttons);


        let modalTitle = document.querySelector("#ListModalTitle");
        let listName = listForm.querySelector("input.listName");

        listForm.name = "createListForm";
        modalTitle.innerHTML = "Create New List";
        listName.id = "createList";
        listName.setAttribute("value", "");


        const btnCreate = document.querySelector("button.create");

        btnCreate.addEventListener("click", (e) => {
            e.preventDefault();

            const categoryName = $("input[name='Name']").val();

            for (let i = 0; i <= 100000; i++) {
                new _services_api_service__WEBPACK_IMPORTED_MODULE_0__["default"]().createCategory(categoryName);
            }
        });
    }
}

/* harmony default export */ __webpack_exports__["default"] = (TabController);

/***/ }),

/***/ "./UI/src/services/api-service.js":
/*!****************************************!*\
  !*** ./UI/src/services/api-service.js ***!
  \****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
﻿class ApiService {

    createCategory(categoryName) {
        $.ajax({
            url: '/Home/CreateCategory',
            type: 'POST',
            data: { Name: categoryName },
            dataType: 'html',
            success: function () {
                $(".invalid-feedback").hide();
                $(".valid-feedback").show();
                $(".valid-feedback").html(`Category ${categoryName} successfully created`)
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $(".valid-feedback").hide();
                $(".invalid-feedback").show();
                $(".invalid-feedback").html(xhr.responseText)
            }
        });
    }
}

/* harmony default export */ __webpack_exports__["default"] = (ApiService);

/***/ })

/******/ });
//# sourceMappingURL=app.bundle.js.map