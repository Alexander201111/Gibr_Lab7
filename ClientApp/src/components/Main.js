import React, { Component } from 'react';
import { TextField, Button } from '@material-ui/core';

export class Main extends Component {

    static displayName = Main.name;

    constructor(props) {
        super(props);
        this.state = {
            mode: 1,
            paramsCout: 7,
            Ii: [1, 1, 1, 1, 1, 1, 1],
            w: [0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02],
            d: [
                10.0054919341489,
                3.03265795024749,
                6.83122010827837,
                1.98478460320379,
                5.09293357450987,
                4.05721328676762,
                0.991215230484718,
            ],
            b: [0, 0, 0],
            A: [
                [1, -1, -1, 0, 0, 0, 0],
                [0, 0, 1, -1, -1, 0, 0],
                [0, 0, 0, 0, 1, -1, -1],
            ],
            result: [],
            extra: [],
        };
    }

    changeCountParams = (event) => {
        const paramsCout = event.target.value;
        this.setState({ paramsCout })
    }

    setCountParams = () => {
        const result = [];
        const Ii = new Array(this.state.paramsCout);
        const w = new Array(this.state.paramsCout);
        const d = new Array(this.state.paramsCout);
        const b = new Array(this.state.paramsCout);
        const extra = [0, 0];
        for (let i = 0; i < this.state.paramsCout; i++) {
            Ii[i] = 0;
            w[i] = 0;
            d[i] = 0;
            b[i] = 0;
        }
        const A = [];
        for (let i = 0; i < 3; i++) {
            const a = [];
            for (let i = 0; i < this.state.paramsCout; i++) {
                a.push(0);
            }
            A.push(a);
        }
        this.setState({ Ii, w, d, b, A, extra, result });
    }

    initDataForTask = (val) => {
        const mode = val;
        const result = [];
        switch (val) {
            case 1: {
                const paramsCout = 7;
                const Ii = [1, 1, 1, 1, 1, 1, 1];
                const w = [0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02];
                const d = [
                    10.0054919341489,
                    3.03265795024749,
                    6.83122010827837,
                    1.98478460320379,
                    5.09293357450987,
                    4.05721328676762,
                    0.991215230484718,
                ];
                const b = [0, 0, 0];
                const A = [
                    [1, -1, -1, 0, 0, 0, 0],
                    [0, 0, 1, -1, -1, 0, 0],
                    [0, 0, 0, 0, 1, -1, -1],
                ];
                this.setState({ mode, paramsCout, Ii, w, d, b, A, result });
                break;
            }
            case 2: {
                const paramsCout = 8;
                const Ii = [1, 1, 1, 1, 1, 1, 1, 1];
                const w = [0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02, 0.667];
                const d = [
                    10.0054919341489,
                    3.03265795024749,
                    6.83122010827837,
                    1.98478460320379,
                    5.09293357450987,
                    4.05721328676762,
                    0.991215230484718,
                    6.66666666666666,
                ];
                const b = [0, 0, 0];
                const A = [
                    [1, -1, -1, 0, 0, 0, 0, 0],
                    [0, 0, 1, -1, -1, 0, 0, 0],
                    [0, 0, 0, 0, 1, -1, -1, 1],
                ];
                this.setState({ mode, paramsCout, Ii, w, d, b, A, result });
                break;
            }
            case 3: {
                const paramsCout = 8;
                const Ii = [1, 1, 1, 1, 1, 1, 1, 1];
                const w = [0.2, 0.121, 0.683, 0.04, 0.102, 0.081, 0.02, 0.667];
                const d = [
                    10.0054919341489,
                    3.03265795024749,
                    6.83122010827837,
                    1.98478460320379,
                    5.09293357450987,
                    4.05721328676762,
                    0.991215230484718,
                    6.66666666666666,
                ];
                const b = [0, 0, 0];
                const A = [
                    [1, -1, -1, 0, 0, 0, 0, 0],
                    [0, 0, 1, -1, -1, 0, 0, 0],
                    [0, 0, 0, 0, 1, -1, -1, 1],
                ];
                const extra = [ 1, -10 ];
                this.setState({ mode, paramsCout, Ii, w, d, b, A, extra, result });
                break;
            }
            default: return;
        }
    }

    render() {
        const paramsCout = this.state.paramsCout;
        return (
            <div>
                <div style={{ display: "flex", alignItems: "baseline" }}>
                    Количество:
                    <TextField value={paramsCout} onChange={this.changeCountParams} style={{ marginLeft: "10px", marginRight: "10px" }} id="standard-basic" />
                    <Button variant="contained" color="primary" onClick={() => this.setCountParams()}>Построить</Button>

                    <Button style={{ marginLeft: "20px" }} variant="contained" color="primary" onClick={() => this.initDataForTask(1)}>Original</Button>
                    <Button style={{ marginLeft: "5px", marginRight: "5px" }} variant="contained" color="primary" onClick={() => this.initDataForTask(2)}>V2</Button>
                    <Button variant="contained" color="primary" onClick={() => this.initDataForTask(3)}>T3</Button>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >i:</b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "40%" }}>
                        {this.state.Ii.map((i, index) => (
                            <TextField style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >w: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "70%" }}>
                        {this.state.w.map((i, index) => (
                            <TextField style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >d: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "70%" }}>
                        {this.state.d.map((i, index) => (
                            <TextField style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >b: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "30%" }}>
                        {this.state.b.map((i, index) => (
                            <TextField style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >A: </b>
                    <div style={{ border: "solid black 3px", width: "50%" }}>
                        {this.state.A.map(elem => (
                            <div style={{ display: "flex", /* border: "solid black 1px" */ }}>
                                {elem.map(i => (
                                    <TextField style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                                ))}
                            </div>
                        ))}
                    </div>
                </div>

                {this.state.mode === 3 && (<div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "90px" }} >Доп. значения: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "30%" }}>
                        {this.state.extra.map((i, index) => (
                            <TextField style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>)}

                <Button style={{ marginTop: "15px", marginLeft: "10px" }} variant="contained" color="primary" onClick={() => this.populateWeatherData()}>Решить</Button>

                {this.state.result && this.state.result.length ? (
                    <div style={{ display: "flex", marginTop: "15px" }}>
                        <b style={{ width: "55px" }} >Result: </b>
                        <div style={{ border: "solid black 3px", width: "20%" }}>
                            {this.state.result.map((elem, index) => (
                                <div style={{ display: "flex" }}>
                                    x{index}={elem}
                                </div>
                            ))}
                        </div>
                    </div>
                ) : null}
            </div>
        );
    }

    async populateWeatherData() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                count: this.state.paramsCout,
                Ii: this.state.Ii,
                w: this.state.w,
                d: this.state.d,
                b: this.state.b,
                A: this.state.A,
                extra: this.state.mode === 3 ? this.state.extra : null,
            })
        };
        const response = await fetch('solver', requestOptions);
        const result = await response.json();
        console.log(result);
        this.setState({ result });
    }
}
