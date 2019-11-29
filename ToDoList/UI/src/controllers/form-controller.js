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
                        minlength: 6,
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
                        required: "Это поле обязательно для заполнения",
                        minlength: "Логин должен быть минимум 4 символа",
                        maxlength: "Максимальное число символов - 16",
                    },
                    password:{
                        required: "Это поле обязательно для заполнения",
                        minlength: "Пароль должен быть минимум 6 символа",
                        maxlength: "Пароль должен быть максимум 16 символов",
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