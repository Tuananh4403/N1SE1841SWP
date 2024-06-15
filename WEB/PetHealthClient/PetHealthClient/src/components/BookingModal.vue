<template>
  <div class="booking-page">
    <div class="booking-form">
      <h2>Book an appointment</h2>
      <div class="form-row">
        <input placeholder="Pet owner" />
        <div>
          <multiselect
            v-model="selectedPetName"
            :options="pets"
            :custom-label="detailPet"
            placeholder=" Select Pet Name"
            label="namePet"
            track-by="idPet"
          >
          </multiselect>
        </div>
      </div>
      <div class="form-row">
        <div>
          <multiselect          
            v-model="selectedDoctor"
            :options="doctors"
            :custom-label="detailDoctor"
            placeholder=" Select doctor"
            label="nameDoctor"
            track-by="idDoctor"
          >
          </multiselect>
        </div>
        <input placeholder="Gender" />
      </div>
      <multiselect
        class="form-service"
        v-model="selectedService"
        :options="services"
        :custom-label="detailService"
        placeholder=" Select Service"
        label="nameService"
        track-by="idService"
      ></multiselect>
      <div class="form-row">
        <flat-pickr v-model="dateValue" :config="dateConfig" placeholder="Date"></flat-pickr>
        <input type="time" class="input-time" placeholder="hh:mm" />
      </div>
      <textarea placeholder="Note"></textarea>
      <div class="form-actions">
        <button class="accept" @click="createBooking">Accept</button>
        <button class="cancel" @click="cancelAction">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script>
import flatPickr from 'vue-flatpickr-component'
import 'flatpickr/dist/flatpickr.css'
import Multiselect from 'vue-multiselect'
import 'vue-multiselect/dist/vue-multiselect.css'
import Cookies from 'js-cookie';
import { useRouter } from 'vue-router';
import axios from 'axios';
  
export default {
  components: {
    flatPickr,
    Multiselect
  },

  data() {
    return {
      dateValue: null,
      timeValue: null,
      dateConfig: {
        dateFormat: 'd/m/Y',
        static: true
      },

      doctors: [
        { idDoctor: 1, nameDoctor: 'Doctor A' },
        { idDoctor: 2, nameDoctor: 'Doctor B' },
        { idDoctor: 3, nameDoctor: 'Doctor C' }
      ],
      selectedDoctor: [],

      pets: [
        { idPet: 1, namePet: 'Pet A' },
        { idPet: 2, namePet: 'Pet B' },
        { idPet: 3, namePet: 'Pet C' }
      ],
      selectedPetName: [],

      services: [
      { idService: 1, nameService: 'Service A' },
      { idService: 2, nameService: 'Service B' },
      { idService: 3, nameService: 'Service C' },
    ],
      selectedService: [],
    }
  },

  methods: {
    cancelAction() {
      this.$emit('close-modal')
    },

    detailDoctor({ nameDoctor, idDoctor }) {
      return `${idDoctor} . ${nameDoctor}`
    },

    detailPet({ namePet, idPet }) {
      return `${idPet} . ${namePet}`
    },
    detailService({ nameService, idService }) {
      return `${idService} . ${nameService}`
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
    }
    }
}
</script>

<style scoped>
.booking-page {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 100px;
}

.booking-form {
  background-color: #fff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 0 15px rgba(0, 0, 0, 0.3);
  max-width: 800px;
  width: 100%;
}

h2 {
  text-align: center;
  margin-bottom: 20px;
}

.form-row {
  display: flex;
  justify-content: space-between;
  margin-bottom: 15px;
}

.form-service {
  margin-bottom: 30px;
}

.form-row input {
  width: 48%;
}

.form-row .flatpickr-input {
  width: 365px;
  display: inline-block;
}

input {
  width: 100%;
  padding: 10px;
  border: 2px solid #000000;
  border-radius: 5px;
  margin-bottom: 15px;
  font-size: 16px;
}

textarea {
  width: 100%;
  padding: 10px;
  border: 2px solid #000000;
  border-radius: 5px;
  margin-bottom: 10px;
  font-size: 16px;
}

.input-time {
  margin-bottom: 5px;
}

.form-actions {
  display: flex;
  justify-content: flex-end;
}

.accept {
  background-color: #4285f4;
  color: #fff;
  border: none;
  padding: 10px 20px;
  border-radius: 3px;
  cursor: pointer;
  margin-left: 10px;
}

.cancel {
  background-color: rgb(181, 175, 175);
  color: white;
  border: none;
  padding: 10px 20px;
  border-radius: 3px;
  cursor: pointer;
}



</style>>