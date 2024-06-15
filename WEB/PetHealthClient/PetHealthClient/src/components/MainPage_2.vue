<template>
    <nav>
      <ul>
        <li><a href="#">Home</a></li>
        <li><a href="#">Medical History</a></li>
        <li><a href="#">Petlast</a></li>
        <li><a href="#">Vaccin Calendar</a></li>
        <li><a href="#">Kennail</a></li>
        <li><a href="#">Service</a></li>
      </ul>
    </nav>
    <div class="header-content bg-image" :style="{ backgroundImage: `url(${backgroundImage})` }">
      <div class="welcome">Welcome Username</div>
    </div>
    <main>
      <div class="content-cards">
        <div class="content-vacxin-cards">
          <h3>Vacxin Calendar</h3>
          <div class="content">abc</div>
        </div>
        <div class="content-kennel-cards">
          <h3>View Kennel</h3>
          <div class="content">abc</div>
        </div>
      </div>
      <div class="button-cards">
        <div class="card">
          <h3>View Pet List</h3>
          <button class="btn-mainpage" @click="navigateTo('petList')">Button</button>
        </div>
        <div class="card">
          <h3>Create Booking</h3>
          <button class="btn-mainpage" @click="showModal = true">Button</button>
        </div>
        <div class="card">
          <h3>About Us</h3>
          <button class="btn-mainpage">Button</button>
        </div>
      </div>
    </main>
    <footer>
      <p>Footer</p>
    </footer>
    <div class="modal" v-if="showModal">
      <booking-modal @close-modal="showModal = false" />
    </div>
</template>

<script>
import { useRouter } from 'vue-router'
import BookingModal from '../components/BookingModal.vue'

export default {
  setup() {
    const router = useRouter()

    const navigateTo = (route) => {
      router.push(`/${route}`)
    }

    return {
      navigateTo
    }
  },

  components: {
    BookingModal
  },
  data() {
    return {
      showModal: false,
      backgroundImage: null,
    }
  },

  mounted() {
    import('@/assets/images/bgmain.png')
      .then((image) => {
        this.backgroundImage = image.default
      })
      .catch((error) => {
        console.error('Error loading image:', error)
      })
  },
}
</script>

<style>
nav {
  background-color: #ffd68e;
  padding: 8px;
}

nav ul {
  list-style-type: none;
  display: flex;
  justify-content: center;
}

nav ul li {
  margin: 0 20px;
}

nav ul li a {
  color: black;
  text-decoration: none;
  font-size: 20px;
}

.header-content {
  color: #fff;
  display: flex;
  justify-content: center;
  height: 455px;
}

.bg-image {
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  height: 455px; 
}

.welcome {
  font-size: 36px;
  margin-top: 200px;
}

.content-cards {
  display: flex;
  justify-content: space-between;
  margin: 50px 0;
}

.button-cards {
  display: flex;
  justify-content: space-between;
  margin: 100px 0;
  align-items: stretch;
}

.content-vacxin-cards {
  background-color: #f2f2f2;
  padding: 20px;
  border-radius: 5px;
  width: 53%;
  height: 400px;
}

.content-kennel-cards {
  background-color: #f2f2f2;
  padding: 20px;
  border-radius: 5px;
  width: 42%;
  height: 400px;
}

.card {
  background-color: #f2f2f2;
  padding: 20px;
  border-radius: 5px;
  width: 48%;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  height: 400px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
  text-align: center;
}

.card h3 {
  margin-bottom: 10px;
}

.content {
  height: 150px;
  background-color: #ddd;
  padding-top: 200px;
}

.btn-mainpage {
  background-color: black;
  color: yellow;
  border: none;
  padding: 10px 20px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
  align-self: center;
}

footer {
  background-color: #f2f2f2;
  padding: 20px;
  text-align: center;
  box-shadow: 0 -2px 4px rgba(0, 0, 0, 0.1);
  height: 100px;
}

.modal {
  position: fixed;
  z-index: 1;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  overflow: auto;
  background-color: rgba(0, 0, 0, 0.4);
}
</style>