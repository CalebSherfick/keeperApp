<template>
    <div class="login">

        <mq-layout mq="xs">
            <form v-if="loginForm" @submit.prevent="loginUser">
                <input type="email" v-model="creds.email" placeholder=" Email" class="mobile-login-form-input mt-5">
                <input type="password" v-model="creds.password" placeholder=" Password"
                    class="mobile-login-form-input mt-3">
                <button type="submit" class="login-form-btn mt-3 mb-1">Login</button>
            </form>
            <form v-else @submit.prevent="register">
                <input type="text" v-model="newUser.username" placeholder=" Name" class="mobile-login-form-input mt-5">
                <input type="email" v-model="newUser.email" placeholder=" Email" class="mobile-login-form-input mt-3">
                <input type="password" v-model="newUser.password" placeholder=" Password"
                    class="mobile-login-form-input mt-3">
                <button type="submit" class="mobile-login-form-btn mt-3 mb-1">Create Account</button>
            </form>
            <div @click="loginForm = !loginForm" class="login-text">
                <p v-if="loginForm">No account? Click to Register</p>
                <p v-else>Already have an account click to Login</p>
            </div>
        </mq-layout>

        <mq-layout mq="sm">
            <form v-if="loginForm" @submit.prevent="loginUser">
                <input type="email" v-model="creds.email" placeholder=" Email" class="mobile-login-form-input mt-5">
                <input type="password" v-model="creds.password" placeholder=" Password"
                    class="mobile-login-form-input mt-3">
                <button type="submit" class="login-form-btn mt-3 mb-1">Login</button>
            </form>
            <form v-else @submit.prevent="register">
                <input type="text" v-model="newUser.username" placeholder=" Name" class="mobile-login-form-input mt-5">
                <input type="email" v-model="newUser.email" placeholder=" Email" class="mobile-login-form-input mt-3">
                <input type="password" v-model="newUser.password" placeholder=" Password"
                    class="mobile-login-form-input mt-3">
                <button type="submit" class="mobile-login-form-btn mt-3 mb-1">Create Account</button>
            </form>
            <div @click="loginForm = !loginForm" class="login-text">
                <p v-if="loginForm">No account? Click to Register</p>
                <p v-else>Already have an account click to Login</p>
            </div>
        </mq-layout>

        <mq-layout mq="md">
            <form v-if="loginForm" @submit.prevent="loginUser">
                <input type="email" v-model="creds.email" placeholder=" Email" class="login-form-input mt-5">
                <br>
                <input type="password" v-model="creds.password" placeholder=" Password" class="login-form-input mt-3">
                <br>
                <button type="submit" class="login-form-btn mt-3 mb-1">Login</button>
            </form>
            <form v-else @submit.prevent="register">
                <input type="text" v-model="newUser.username" placeholder=" Name" class="login-form-input mt-5">
                <br>
                <input type="email" v-model="newUser.email" placeholder=" Email" class="login-form-input mt-3">
                <br>
                <input type="password" v-model="newUser.password" placeholder=" Password" class="login-form-input mt-3">
                <br>
                <button type="submit" class="login-form-btn mt-3 mb-1">Create Account</button>
            </form>
            <div @click="loginForm = !loginForm" class="login-text">
                <p v-if="loginForm">No account? Click to Register</p>
                <p v-else>Already have an account click to Login</p>
            </div>
        </mq-layout>

        <mq-layout mq="lg">
            <form v-if="loginForm" @submit.prevent="loginUser">
                <input type="email" v-model="creds.email" placeholder=" Email" class="login-form-input mt-5">
                <br>
                <input type="password" v-model="creds.password" placeholder=" Password" class="login-form-input mt-3">
                <br>
                <button type="submit" class="login-form-btn mt-3 mb-1">Login</button>
            </form>
            <form v-else @submit.prevent="register">
                <input type="text" v-model="newUser.username" placeholder=" Name" class="login-form-input mt-5">
                <br>
                <input type="email" v-model="newUser.email" placeholder=" Email" class="login-form-input mt-3">
                <br>
                <input type="password" v-model="newUser.password" placeholder=" Password" class="login-form-input mt-3">
                <br>
                <button type="submit" class="login-form-btn mt-3 mb-1">Create Account</button>
            </form>
            <div @click="loginForm = !loginForm" class="login-text">
                <p v-if="loginForm">No account? Click to Register</p>
                <p v-else>Already have an account click to Login</p>
            </div>
        </mq-layout>
    </div>




</template>

<script>
    export default {
        name: "login",
        mounted() {
            //checks for valid session
            this.$store.dispatch("authenticate");
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>

<style scoped>
    .login-text {
        color: #f2f2f2;
    }

    .login-form-input {
        width: 50%;
        padding: 8px;
        font-size: 15px;
        border: 1px solid rgba(255, 255, 255, .38);
        border-radius: 5px;
        box-sizing: border-box;
        background-color: #45484f;
        box-shadow: inset 0 2px 6px 0 rgba(0, 0, 0, .26);
        color: #696969;
        text-align: center;
        outline: 0;
    }

    .login-form-btn {
        display: inline-block;
        color: #333;
        padding: 4px 15px;
        margin: 0 5px;
        border-radius: 5px;
        background-image: linear-gradient(to bottom, #e0e0e0, #B6BECB);
        box-shadow: 0 2px 4px 0 rgba(0, 0, 0, .5);
    }

    .login-form-btn:hover {
        translogin-form: scale(1.02);
        cursor: pointer;
    }

    .form-btn:active {
        box-shadow: none;
        transform: scale(1.01);
    }

    .mobile-login-form-input {
        width: 90%;
        padding: 8px;
        font-size: 15px;
        border: 1px solid rgba(255, 255, 255, .38);
        border-radius: 5px;
        box-sizing: border-box;
        background-color: #45484f;
        box-shadow: inset 0 2px 6px 0 rgba(0, 0, 0, .26);
        color: #696969;
        text-align: center;
        outline: 0;
    }

    .mobile-login-form-btn {
        display: inline-block;
        color: #333;
        padding: 4px 15px;
        margin: 0 5px;
        border-radius: 5px;
        background-image: linear-gradient(to bottom, #e0e0e0, #B6BECB);
        box-shadow: 0 2px 4px 0 rgba(0, 0, 0, .5);
    }
</style>