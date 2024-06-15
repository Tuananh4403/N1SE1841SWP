<template>
  <div id="app">
    <div class="full-screen-background" :style="{ backgroundImage: `url(${backgroundImage})` }">
      <div class="sign-in-container">
        <h1>Sign in</h1>
        <p>New user? <router-link to="/register">Create an account</router-link></p>
        <form @submit.prevent="login">
          <input
            type="email"
            placeholder="Email"
            v-model="email"
            @input="validateEmail"
            @blur="validateEmail"
          />
          <p v-if="emailError" class="error">{{ emailError }}</p>
          <input type="password" placeholder="Password" v-model="password" />
          <button type="submit">Login</button>
        </form>
        <div class="or">----------Or----------</div>
        <div class="social-login">
          <button class="google-btn" @click="loginWithGoogle">
            <i class="fab fa-google"></i> Login with Google
          </button>
          <button class="facebook-btn" @click="loginWithFacebook">
            <i class="fab fa-facebook-f"></i> Login with Facebook
          </button>
        </div>
      </div>
    </div>
  </div>
  <link
    rel="stylesheet"
    href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"
    integrity="sha512-..."
    crossorigin="anonymous"
  />
</template>

<script>
import axios from 'axios'
export default {
  data() {
    return {
      backgroundImage: null,
      email: '',
      emailError: '',
      password: ''
    }
  },

  mounted() {
    import('@/assets/images/background.png')
      .then((image) => {
        this.backgroundImage = image.default
      })
      .catch((error) => {
        console.error('Error loading image:', error)
      })
  },

  methods: {
    validateEmail() {
      const emailRegex = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/
      if (!emailRegex.test(this.email)) {
        this.emailError = 'Please enter a valid email address'
      } else {
        this.emailError = ''
      }
    },

    
    loginWithGoogle() {
      axios
        .post('http://localhost:3000/auth/google')
        .then((response) => {
          console.log(response.data)
        })
        .catch((error) => {
          console.error(error)
        })
    },

    loginWithFacebook() {
      axios
        .post('http://localhost:3000/auth/facebook')
        .then((response) => {
          console.log(response.data)
        })
        .catch((error) => {
          console.error(error)
        })
    }
  }
}
</script>

<style>
.full-screen-background {
  background-size: cover;
  background-position: center;
  height: 100vh;
  display: flex;
}

.signup-container {
  max-width: 450px;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f2f2f2;
  align-items: center;
}

.name-inputs {
  display: flex;
  justify-content: space-between;
  gap: 10px;
}

input[type='email'],
input[type='password'],
input[type='text'] {
  width: 100%;
  padding: 12px 20px;
  margin: 6px 0;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button[type='submit'] {
  background-color: #4285f4;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  width: 100%;
}

.or {
  text-align: center;
  margin: 10px 0;
}

.social-buttons button {
  width: 100%;
  padding: 12px 20px;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
  cursor: pointer;
}

.google-btn {
  background-color: #fff;
  color: #757575;
}

.facebook-btn {
  background-color: #fff;
  color: #757575;
}

.error {
  color: red;
}
</style>