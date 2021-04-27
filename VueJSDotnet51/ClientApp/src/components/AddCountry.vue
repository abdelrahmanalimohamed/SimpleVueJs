

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

<template>

    <h1>Insert New Country</h1>

    <form class="form-horizontal" @submit.prevent="addCountry">

        <div class="form-group">
            <label class="control-label col-sm-2" for="email">Country Code :</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="text" placeholder="Country Code" v-model="country.country_id">
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-sm-2" for="pwd">Country Name :</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="pwd" placeholder="Country Name" v-model="country.country_name">
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button type="submit" class="btn btn-primary">Submit</button>
            </div>
        </div>

    </form>


</template>

<script>
    import axios from 'axios'
    export default {
        data() {
            return {
                country: {}
            }
        },
        methods: {
            addCountry() {
                axios
                    .post('https://localhost:44350/api/Country/insertcountry', this.country)
                    .then(response => (
                        this.isSuccessfully = true ,
                     this.alertModalTitle = 'Successfully' ,
                      this.alertModalContent = 'Successfully inserted new Country',
                        this.$router.push({ name: 'home' })
                    ))
                    .catch(err => console.log(err))
                    .finally(() => this.loading = false)
            }
        }
    }
</script>

