import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    myVaults: [],
    keeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setMyVaults(state, vaults) {
      state.myVaults = vaults
    },
    addMyVaults(state, newVault) {
      state.myVaults.push(newVault)
    },
    removeVault(state, vaultId) {
      let arr = state.myVaults
      for (let i = 0; i < arr.length; i++) {
        let vault = arr[i];
        if (vault.id == vaultId) {
          arr.splice(i, 1);
          return
        }
      }
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    addKeeps(state, newKeep) {
      state.keeps.push(newKeep)
    },
    removeKeep(state, keepId) {
      let arr = state.keeps
      for (let i = 0; i < arr.length; i++) {
        let keep = arr[i];
        if (keep.id == keepId) {
          arr.splice(i, 1);
          return
        }
      }
    },
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'dashboard' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'dashboard' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'dashboard' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'login' })
        })
    },

    //#region  --VAULTS--

    //CREATE VAULT
    createVault({ commit, dispatch }, payload) {
      api.post('vaults', payload)
        .then(res => {
          commit('addMyVaults', res.data)
        })
    },

    //GET VAULTS
    getVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setMyVaults', res.data)
        })
    },

    //DELETE VAULT
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          commit('removeVault', vaultId)
        })
    },

    //#endregion

    //#region  --KEEPS--

    //CREATE KEEP
    createKeep({ commit, dispatch }, payload) {
      api.post('keeps', payload)
        .then(res => {
          commit('addKeeps', res.data)
        })
    },

    //GET KEEPS
    getKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    //DELETE KEEP
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          commit('removeKeep', keepId)
        })
    },

    //#endregion


    //#region  --VAULTKEEPS--

    //CREATE KEEP
    createVaultKeep({ commit, dispatch }, payload) {
      api.post('vaultkeeps', payload)
    },

    //GET KEEPS
    getVaultKeeps({ commit, dispatch }, vaultId) {
      debugger
      api.get('vaultkeeps/{{vaultId}}/keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    //DELETE KEEP
    deleteVaultKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          commit('removeKeep', keepId)
        })
    }

    //#endregion






  }
})
