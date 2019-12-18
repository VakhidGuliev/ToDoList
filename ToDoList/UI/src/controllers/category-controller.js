import ApiService from "../services/api-service";
import ModalService from "../services/modal-service";

class CategoryController {
    constructor() {}

    CreateCategory() {
        
        new ModalService().CreateCategory();
        
        const btnCreate = document.querySelector("button.create");

        if (!btnCreate.classList.contains("create")) {
            return;
        }
        
        btnCreate.addEventListener("click", (e) => {
            e.preventDefault();

            const categoryName = $("input[name='Name']").val();

            new ApiService().createCategory(categoryName);
        });
    }
    
    EditCategory(e){
        new ModalService().EditCategory(e);

        let btnEditSave = document.querySelector("button.save");

        if (!btnEditSave.classList.contains("save")) {
            return;
        }
        
        btnEditSave.addEventListener("click", (e)=> {
            e.preventDefault();

            const categoryName = $("input[name='Name']").val();

            console.log("edit task");
        });
    }
    
    switchCategory(e){
        new ModalService().showTab(e)
    }
}

export default CategoryController;