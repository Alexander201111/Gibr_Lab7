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
            extra: [],
            result: [],
            check: false,
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
                const extra = [1, -10];
                this.setState({ mode, paramsCout, Ii, w, d, b, A, extra, result });
                break;
            }
            default: return;
        }
    }

    changeValue = (par, event, index1, index2 = undefined) => {
        const value = +event.target.value;
        switch(par) {
            case 'Ii': {
                this.state.Ii[index1] = value;
                this.setState({ Ii: this.state.Ii });
                break;
            };
            case 'w': {
                this.state.w[index1] = value;
                this.setState({ w: this.state.w });
                break;
            };
            case 'd': {
                this.state.d[index1] = value;
                this.setState({ d: this.state.d });
                break;
            };
            case 'b': {
                this.state.b[index1] = value;
                this.setState({ b: this.state.b });
                break;
            };
            case 'A': {
                this.state.A[index1][index2] = value;
                this.setState({ A: this.state.A });
                break;
            };
            case 'extra': {
                this.state.extra[index1] = value;
                this.setState({ extra: this.state.extra });
                break;
            };
        }
    }

    render() {
        const paramsCout = this.state.paramsCout;
        const reducibility = ["", "", ""];
        const reducibilityNums = [0, 0, 0];
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < this.state.paramsCout; j++) {
                if (this.state.A[i][j] !== 0) {
                    reducibility[i] += (this.state.A[i][j] * this.state.result[j]).toString();
                    reducibilityNums[i] += this.state.A[i][j] * this.state.result[j];
                }
            }
            reducibilityNums[i] = Math.round(reducibilityNums[i]);
        }
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
                            <TextField onChange={(event) => this.changeValue("Ii", event, index)} style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >w: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "70%" }}>
                        {this.state.w.map((i, index) => (
                            <TextField onChange={(event) => this.changeValue("w", event, index)} style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >d: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "70%" }}>
                        {this.state.d.map((i, index) => (
                            <TextField onChange={(event) => this.changeValue("d", event, index)} style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >b: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "30%" }}>
                        {this.state.b.map((i, index) => (
                            <TextField onChange={(event) => this.changeValue("b", event, index)} style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>

                <div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "30px" }} >A: </b>
                    <div style={{ border: "solid black 3px", width: "50%" }}>
                        {this.state.A.map((elem, index1) => (
                            <div style={{ display: "flex", /* border: "solid black 1px" */ }}>
                                {elem.map((i, index2) => (
                                    <TextField onChange={(event) => this.changeValue("A", event, index1, index2)} style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                                ))}
                            </div>
                        ))}
                    </div>
                </div>

                {this.state.mode === 3 && (<div style={{ display: "flex", marginTop: "15px" }}>
                    <b style={{ width: "90px" }} >Доп. значения: </b>
                    <div style={{ display: "flex", border: "solid black 3px", width: "30%" }}>
                        {this.state.extra.map((i, index) => (
                            <TextField onChange={(event) => this.changeValue("A", event, index)} style={{ border: "solid black 1px", marginLeft: "10px" }} value={i} id="standard-basic" />
                        ))}
                    </div>
                </div>)}

                <Button style={{ marginTop: "15px", marginLeft: "10px" }} variant="contained" color="primary" onClick={() => this.populateWeatherData()}>Решить</Button>

                {this.state.result && this.state.result.length ? (
                    <div>
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
                        <div>
                            Баланс сводится: {this.state.check ? "ДА" : "НЕТ"}
                            <div style={{ border: "solid black 3px" }}>
                                {[0, 1, 2].map((e) => (
                                    <div>{reducibility[e]}={reducibilityNums[e]}</div>
                                ))}
                            </div>
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

        let check = true;
        for (let i = 0; i < 3; i++) {
            let resultForCheck = 0;
            for (let j = 0; j < this.state.paramsCout; j++) { resultForCheck += result[j] * this.state.A[i][j]; }
            if (Math.round(resultForCheck) != 0) { check = false; break; }
        }

        this.setState({ result, check });
    }
}
