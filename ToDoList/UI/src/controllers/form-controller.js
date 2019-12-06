import { log } from "util";

class FormController {
    constructor(form) {
        this.form = form;
    }

    submit() {
        this.form.addEventListener('submit', (e) => {
            e.preventDefault();

            const currentForm = e.target;

            this.validate(currentForm)
            
        })
    }

    validate(form) {

        if (form.name === "registration") {
       
            form.submit();

      
        }

        if (form.name === "authForm") {
            console.log(form);
            form.submit();
        }
    }
}

export default FormController;