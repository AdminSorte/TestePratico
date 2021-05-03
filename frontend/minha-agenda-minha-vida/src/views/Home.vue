<template>
  <div class="home">
    <v-spacer height="100px"></v-spacer>
    <ScheduleTable />
  </div>
</template>

<script>
import ScheduleTable from "../components/ScheduleTable.vue";

export default {
  name: "Home",
  components: {
    ScheduleTable,
  },

  created() {
    if(!localStorage.accessToken){
      this.$router.push({ name: "Login" });
    }
    return;
  }
};

</script>


<style lang="scss" scoped>
</style>