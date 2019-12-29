import ApiService from "../services/api-service";

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

                new ApiService().createTask(taskData)
        }
}

export default TaskController;