import ApiService from "../services/api-service";

class CategoryController {
    constructor() {}

    CreateCategory() {

        //open Modal create category
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


        //createCategory
        document.querySelector("button.create").addEventListener("click", (e) => {
            e.preventDefault();

            const categoryName = $("input[name='Name']").val();

            new ApiService().createCategory(categoryName);
        });
    }
}

export default TabController;