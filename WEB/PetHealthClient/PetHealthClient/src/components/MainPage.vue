<template>
    <h1>Main Page here</h1>
    <button @click="navigateTo('login')">Login</button>
    <button @click="navigateTo('register')">Register</button>
</template>

<script>
import { useRouter } from 'vue-router'
export default {
  setup() {
    const router = useRouter()

    const navigateTo = (route) => {
      router.push(`/${route}`)
    }

    return {
      navigateTo
    }
  }
}
</script>

<style>
</style>