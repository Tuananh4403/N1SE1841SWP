<template>
  <div id="app">
    <div class="container">
      <h1>List of your pets</h1>
    </div>
    <table>
      <thead>
        <tr>
          <th>No</th>
          <th>Pet Name</th>
          <th>Kind of pet</th>
          <th>Gender</th>
          <th>Birthday</th>
          <th>Species</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pet, index) in pets" :key="index">
          <td>{{ index + 1 }}</td>
          <td>{{ pet.name }}</td>
          <td>{{ pet.kind }}</td>
          <td>{{ pet.gender }}</td>
          <td>{{ pet.birthday }}</td>
          <td>{{ pet.species }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      pets: [
        { name: 'Buddy', kind: 'Dog', gender: 'Male', birthday: '2020-01-01', species: 'Canine' },
        { name: 'Mittens', kind: 'Cat', gender: 'Female', birthday: '2019-05-05', species: 'Feline' },
        { name: 'Goldie', kind: 'Fish', gender: 'Male', birthday: '2021-07-07', species: 'Goldfish' }
      ]
    };
  }
};
</script>

<style scoped>
.container {
  margin: 20px;
  text-align: center;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
}

th {
  background-color: #f2f2f2;
  text-align: left;
}
</style>
