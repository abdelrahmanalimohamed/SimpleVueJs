

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
            <label class="control-label col-sm-2" for="pwd">Region Name :</label>
            <div class="col-sm-10">
                <select v-model="country.region_id">>
                    <option v-for="option in countries" v-bind:value="option.region_id" >
                        {{ option.region_name }}
                    </option>
                </select>
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
        data: function() {
            return {
                countries: [],
                country: {}

            }
        },

        created() {
            axios
                .get('https://localhost:44350/api/Country/regions')
                .then(response => {
                    this.countries = response.data;
                });
        },
        methods: {
            addCountry() {
                axios
                    .post('https://localhost:44350/api/Country/insertcountry', this.country)
                    .then(response => (
                      
                        this.$router.push({ name: 'Home' })
                    ))
                    .catch(err => console.log(err))
                    .finally(() => this.loading = false)
            }
        }
    }
</script>

