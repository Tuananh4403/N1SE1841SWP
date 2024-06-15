<template>
  <div id="app" class="container">
    <div class="form-container">
      <h2>Create your pet</h2>
      <form @submit.prevent="updatePet">
        <div class="form-row">
          <div class="form-group">
            <input id="pet-name" v-model="pet.name" type="text" placeholder="Pet Name" />
          </div>
          <div class="form-group">
            <input id="kind-of-pet" v-model="pet.kind" type="text" placeholder="Kind of pet" />
          </div>
        </div>
        <div class="form-row">
          <div class="form-group">
            <input id="gender" v-model="pet.gender" type="text" placeholder="Gender" />
          </div>
          <div class="form-group">
            <input id="species" v-model="pet.species" type="text" placeholder="Species" />
          </div>
        </div>
        <div class="form-row">
          <div class="form-group">
            <input id="birthday" v-model="pet.birthday" type="date" placeholder="Birthday" />
          </div>
        </div>
        <div class="form-actions">
          <button type="submit" class="update-button">Update</button>
          <button type="button" class="cancel-button" @click="cancelUpdate">Cancel</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      pet: {
        name: '',
        kind: '',
        gender: '',
        species: '',
        birthday: ''
      }
    };
  },
  methods: {
    updatePet() {
      console.log('Pet data updated:', this.pet);
    },
    cancelUpdate() {
      this.pet = {
        name: '',
        kind: '',
        gender: '',
        species: '',
        birthday: ''
      };
      console.log('Update canceled');
    }
  }
};
</script>

<style scoped>
.container {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background-color: #f8f8f8;
}

.form-container {
  border: 1px solid #ddd;
  padding: 40px;
  border-radius: 10px;
  max-width: 600px;
  width: 100%;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  background-color: #fff;
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

.form-group {
  flex: 1;
  margin-right: 20px;
}

.form-group:last-child {
  margin-right: 0;
}

input {
  width: 100%;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-sizing: border-box;
  font-size: 16px;
}

.form-actions {
  display: flex;
  justify-content: flex-end;
  margin-top: 20px;
}

.update-button {
  background-color: #8a2be2;
  color: white;
  padding: 12px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-right: 10px;
}

.cancel-button {
  background-color: #ccc;
  color: white;
  padding: 12px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.update-button:hover {
  background-color: #6a1bbd;
}

.cancel-button:hover {
  background-color: #a0a0a0;
}
</style>
