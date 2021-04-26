<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<template>

    <h1>Country Data</h1>

    <router-link to="/InsertCountry" tag="button" class="btn btn-success">Create New Country</router-link>

    <br />
    <br />
    <br />
    <br />

    <table class="table">
        <thead class="thead-dark">
            <tr>

                <th>Country ID</th>
                <th>Country Name</th>
                <th>Region Name</th>
                <th>Update</th>
                <th>Delete</th>

            </tr>
        </thead>

        <tbody>
            <tr v-for="country in countries" :key="country.country_id">
                <td>{{ country.country_id }}</td>
                <td>{{ country.country_name }}</td>
                <td>{{ country.region_name }}</td>

                

                <td>
                    <router-link :to="{name: 'UpdateCountry', params: { id: country.country_id }}" class="btn btn-success">Update</router-link>
                </td>

                <td>
                    <button class="btn btn-danger" @click="deleteCountry(country.country_id)">Delete</button>
                </td>

            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        data() {
            return {
                countries: []
            }
        },
        created() {
            axios
                .get('https://localhost:44350/api/Country')
                .then(response => {
                    this.countries = response.data;
                });
        },
        methods: {
            deleteCountry(id) {
                axios
                    //  .delete(`/api/category/${id}`)
                    .delete('https://localhost:44350/api/Country/deletecountry/' + id)
                    .then(response => {
                        let i = this.countries.map(data => data.id).indexOf(id);
                        this.countries.splice(i, 1)
                    });
            }
        }
    }
</script>

<!--<script>
    import axios from 'axios'

    export default {
        name: "Counter",
        mounted: function () {
            this.getCountries()
            console.log('mounted: got here')
        },
        data: function () {
            return {
                message: 'Countries List Row',
                countries: []
            }
        },
        methods: {
            getCountries: function () {
                var self = this
                const url = 'https://localhost:44350/api/Country'
                axios.get(url, {
                    dataType: 'json',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    mode: 'no-cors',
                    credentials: 'include'
                })
                    .then(function (response) {
                      
                        console.log(response.data);
                        self.countries = response.data
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }
        }
    }
</script>-->

<!--<script>
    import axios from 'axios'

    export default {
        methods: {
            deleteCountry(id) {
                this.axios
                    .delete(`https://localhost:44350/api/Country/deletecountry/${id}`)
                    .then(response => {
                        let i = this.products.map(data => data.id).indexOf(id);
                        this.products.splice(i, 1)
                    });
            }
        }
    }
</script>-->