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

        if (form.name == "authForm") {
            console.log(form.name)
        }

        if (form.name == "registration") {
            console.log(form.name)
        }

    }
}

export default FormController;