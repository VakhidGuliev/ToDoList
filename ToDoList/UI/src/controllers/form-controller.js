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
            console.log(form.name);
            $(form).validate({
                submitHandler: function(form) {
                    form.submit();
                },
                rules:{
                    firstName:{
                        required: true,
                        minlength: 4,
                        maxlength: 16,
                    },
                    lastName:{
                        required: true,
                        minlength: 4,
                        maxlength: 16,
                    },
                    birthday: {
                        required: true
                    },
                    email:{
                        required:true
                    },
                    phone: {
                        required: true
                    },
                    password: {
                        required: true
                    },
                    confirmPassword: {
                        required: true
                    }
                },
                messages:{
                    login:{
                        required: "This field is required",
                        minlength: "Login must be at least 4 characters",
                        maxlength: "The maximum number of characters is 16",
                    },
                    password:{
                        required: "This field is required",
                        minlength: "Login must be at least 4 characters",
                        maxlength: "The maximum number of characters is 16",
                    },
                }
            })
        }

        if (form.name === "authForm") {
           console.log(form);
        }
    }
}

export default FormController;