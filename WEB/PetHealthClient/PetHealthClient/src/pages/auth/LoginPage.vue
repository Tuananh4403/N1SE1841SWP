<template>
  <div id="app">
    <div class="full-screen-background" :style="{ backgroundImage: `url(${backgroundImage})` }">
      <div class="sign-in-container">
        <h1>Sign in</h1>
        <p>New user? <router-link to="/register">Create an account</router-link></p>
        <form @submit.prevent="login">
          <input
            placeholder="Email"
            v-model="email"
          />
          <p v-if="emailError" class="error">{{ emailError }}</p>
          <input v-model="password" type="password" placeholder="Password" />
          <button @click="handleLogin" type="submit">Login</button>
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

<script >
import axios from 'axios';
import Cookies from 'js-cookie';
import { useRouter } from 'vue-router';

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
    async handleLogin() {
      try {
        let data = JSON.stringify({
          "username": "tes5",
          "password": "123"
        });

        let config = {
          method: 'post',
          maxBodyLength: Infinity,
          url: 'http://localhost:4000/api/auth/authenticate',
          headers: { 
            'Content-Type': 'application/json'
          },
          data: data
        };

        const response = await axios.request(config);
        Cookies.set('auth_token', response.data.token, { expires: 7 });
        const router = this.$router;
        router.push('/main'); // Redirect to the main page
      } catch (error) {
        console.error(error);
      }
    },

    loginWithGoogle() {
      axios
        .post('/api/auth/google')
        .then((response) => {
          console.log(response.data)
        })
        .catch((error) => {
          console.error(error)
        })
    },

    loginWithFacebook() {
      axios
        .post('/api/auth/facebook')
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
  justify-content: center;
  align-items: center;
}

.sign-in-container {
  background-color: #f2f2f2;
  padding: 30px;
  border-radius: 5px;
  border: 1px solid #ccc;
  max-width: 400px;
  margin-left: 700px;
}

input[type='email'],
input[type='password'] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
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
  margin: 20px 0;
}

.social-login button {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
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
  background-color: #3b5998;
  color: #fff;
}

.social-login button i {
  margin-right: 8px;
}

.error {
  color: red;
}
</style>


