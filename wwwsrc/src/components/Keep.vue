<template>
  <div :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-4', lg: 'col-3'})">
    <img :src="keep.img">
    <p>{{keep.name}}</p>
    <p>{{keep.description}}</p>
    <button class="btn btn-danger px-4 mb-2" @click="deleteKeep(keep.id)">Delete</button>
  </div>
</template>

<script>
  export default {
    name: "keep",
    props: ["keep"],
    data() {
      return {};
    },
    computed: {},
    methods: {
      deleteKeep(keepId) {
        this.$store.dispatch("deleteKeep", keepId);
      }
    },
    components: {}
  };
</script>