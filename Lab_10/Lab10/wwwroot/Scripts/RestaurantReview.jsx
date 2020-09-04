var RestaurantReview = React.createClass({

    getInitialState: function () {
        return {
            name: this.props.data.name,
            address: this.props.data.location,
            summary: this.props.data.summary,
            rating: this.props.data.rating,
            saved: "",
            showConfirm: { display: "none" }
        };
    },

    handleAddressChange: function (newAddress) {
        this.setState({ address: newAddress });
    },
    handleSummaryChange: function (e) {
        this.setState({ summary: e.target.value });
    },
    handleRatingChange: function (e) {
        this.setState({ rating: e.target.value });
    },

    submitChange: function () {
        var restInfo = { name: this.state.name, Location: this.state.address, Summary: this.state.summary, Rating: this.state.rating }
        $.ajax(this.props.updateUrl,
            {
                type: 'POST',
                dataType: 'json',
                data: { restInfo: JSON.stringify(restInfo) },
                success: function (returnData) {
                    if (returnData != null) {
                        this.setState({ showConfirm: { display: "inherit" } });
                        this.setState({ saved: returnData });
                    }
                }.bind(this)
            });
    },
    render: function () {

        return (
            <div className="row">
                <div className="col-md-9">
                    <fieldset>
                        <legend>{this.state.name}</legend>

                        <Address address={this.state.address} onAddressChange={this.handleAddressChange} />

                        <div className="row">
                            <div className="col-md-2 label-align">
                                <label htmlFor="txtSummary">Summary:</label>
                            </div>
                            <div className="col-md-10">
                                <textarea id="txtSummary" className="form-control" style={{ width: "100%", height: 100 }}
                                    value={this.state.summary} onChange={this.handleSummaryChange}></textarea>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-2 label-align">
                                <label htmlFor="drpRating">Rating: </label>
                            </div>
                            <div className="col-md-10">
                                <select id="drpRating" className="form-control"
                                    value={this.state.rating} onChange={this.handleRatingChange}>
                                    <option key="1" value="1">1</option>
                                    <option key="2" value="2">2</option>
                                    <option key="3" value="3">3</option>
                                    <option key="4" value="4">4</option>
                                    <option key="5" value="5">5</option>
                                </select>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-2 label-align">
                                <button className="btn btn-primary" type="button" onClick={this.submitChange}>Save</button>
                            </div>
                            <div className="col-md-10">
                                <span className="form-control alert-success" style={this.state.showConfirm} >{this.state.saved}</span>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        );
    }
});
