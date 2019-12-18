import ModalService from "./modal-service";
import RenderService from "./render-service";

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
                new RenderService().renderCategory();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $(".valid-feedback").hide();
                $(".invalid-feedback").show();
                $(".invalid-feedback").html(xhr.responseText)
            }
        });
    }
    editCategory(categoryName){
        console.log(categoryName);
    }

    getTasks() {
        $.ajax({
            url: '/Home/CategoryList',
            type: 'GET',
            success: function (data) {
                console.log(data)
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.responseText)
            }
        });
    }
}

export default ApiService;