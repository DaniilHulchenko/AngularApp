const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/movie",
    ],
    target: "https://localhost:7224",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
