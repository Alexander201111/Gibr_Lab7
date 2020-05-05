import React, { Component } from 'react';
import { TextField, Button } from '@material-ui/core';

export default class Extra extends Component {

    constructor(props) {
        super(props);
        this.state = {
            extraCount: 1,
            extra: [[1, -10, 0, 0, 0, 0, 0]],
        };
    }

    componentDidMount() {
        this.props.changeExtra(this.state.extra)
    }

    changeCountParams = (event) => {
        const extraCount = event.target.value;
        let extra;
        if(extraCount == 0) {
            extra = undefined
        } else {
            extra = new Array(extraCount).fill(0).map(() => new Array(this.props.paramsCout).fill(0));
        }
        this.setState({ extraCount, extra })
        this.props.changeExtra(extra)
    }

    setCountParams = () => {
        const extra = [];
        for (let i = 0; i < 3; i++) {
            const a = [];
            for (let i = 0; i < this.state.paramsCout; i++) {
                a.push(0);
            }
            extra.push(a);
        }
        this.setState({ extra });
    }

    changeValue = (event, index1, index2) => {
        this.state.extra[index1][index2] = event.target.value;
        this.setState({ extra: this.state.extra });
        this.props.changeExtra(this.state.extra)
    }

    render() {
        return (
            <div>
                <div style={{ display: "flex", alignItems: "baseline", marginTop: "15px" }}>
                    Количество доп. ограничений:
                    <TextField value={this.state.extraCount} onChange={this.changeCountParams} style={{ marginLeft: "10px", marginRight: "10px" }} id="standard-basic" />
                </div>

                {this.state.extra && <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "120px" }} >Доп. ограничения: </b>
                    <div style={{ border: "solid black 3px", width: "50%" }}>
                        {this.state.extra.map((elem, index1) => (
                            <div style={{ display: "flex" }}>
                                {elem.map((i, index2) => (
                                    <TextField onChange={(event) => this.changeValue(event, index1, index2)} style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                                ))}
                            </div>
                        ))}
                    </div>
                </div>}
            </div>
        );
    }
}
