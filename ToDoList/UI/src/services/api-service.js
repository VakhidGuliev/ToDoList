import ModalService from "./modal-service";
import RenderService from "./render-service";
import {fbTransformToArray} from "./transform-service";

class ApiService {

    createCategory(categoryName) {
        $.ajax({
            url: '/Home/CreateCategory',
            type: 'POST',
            data: {Name: categoryName},
            dataType: 'html',
            success: function () {
                $(".invalid-feedback").hide();
                $(".valid-feedback").show();
                $(".valid-feedback").html(`Category ${categoryName} successfully created`);
                new RenderService().renderCategory();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $(".valid-feedback").hide();
                $(".invalid-feedback").show();
                $(".invalid-feedback").html(xhr.responseText)
            }
        });
    }
    editCategory(categoryName) {
        $.ajax({
            url: '/Home/Edit',
            type: 'PUT',
            data: { Name: categoryName },
            dataType: 'html',
            success: function () {
                alert("edit succsess")
                this.getTasks();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xht.responseText)
            }
        });
    }


    getTasks() {
        $.ajax({
            url: '/Home/CategoryList',
            type: 'GET',
            success: function (data) {
                
                
                const Tab = new ModalService().Tabs();
                const TaskObject = data;
                
                
                const promise = fbTransformToArray(TaskObject);

                promise.then(function (arr) {
                    let objectKeys = Object.keys(TaskObject);
                    

                    //Update database
                    document.querySelector("#myList").innerHTML = "";
                    document.querySelector(".tab-content").innerHTML = "";

                    objectKeys.forEach((value, index, array) => {
                        array = arr;
                        
                        const objs = array[value];

                        Tab.listContainer.insertAdjacentHTML("beforeend", Tab.renderLists(objs.name, index, array[index].tasksCount));
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


}

export default ApiService;