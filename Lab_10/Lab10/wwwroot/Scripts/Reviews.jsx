var Reviews = React.createClass({

    getInitialState: function () {
        return { data: [] };
    },

    componentDidMount: function () {
        $.ajax(this.props.initialUrl,
            {
                type: "GET",
                dataType: "json",
                success: function (returnData) {
                    if (returnData != null) {
                        this.setState({ data: returnData });
                    }
                }.bind(this),
                error: function (jqRequest, status, e) {
                    console.log(status);
                    console.log(jqRequest);
                    console.log(e);
                }
            });
    },

    render: function () {

        function makeRestaurantReviewList(x, index) {
            return <RestaurantReview data={x} key={index} updateUrl={this.props.updateUrl} />;
        }

        return (
            <div>
                <h1>Restaurant Reviews</h1>

                {this.state.data.map(makeRestaurantReviewList, this)}
            </div>
        );
    }
});
