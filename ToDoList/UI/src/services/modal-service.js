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

    DeleteCategory() {}


    Tabs() {
        return {
            listContainer: document.querySelector("#myList"),
            tabContainer: document.querySelector(".tab-content"),
            renderLists: function (list, index, array) {
                return `<a class="list-group-item list-group-item-action" data-name="${list}" data-index="${index}" role="tab">
                                <span class="listName"><i class="fa fa-list-ul"></i>${list}</span>
                                <span class="listCount badge badge-primary" title="Task count">${array}</span>
                                <span class="editList" title="List options"><i class="fa fa-edit"></i></span>
                            </a>`
            },
            renderTabs: function (tab, index) {
                return `<div class="tab-pane" id="${tab}" data-name="${tab}" data-index="${index}" role="tabpanel"></div>`
            }
        };
    }
}

export default ModalService;