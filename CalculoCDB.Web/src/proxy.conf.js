const PROXY_CONFIG = [
  {
    context: [
      "/cbd",
    ],
    target: "https://localhost:7190/",
    secure: true
  }
]

module.exports = PROXY_CONFIG;
