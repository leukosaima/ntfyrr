# ntfyrr

A bridge between some services' webhook notifications to ntfy, for those that don't currently support ntfy natively.

---

#### Services supported

- Overseerr

#### Environment Variables to define when running ntfyrr

- `TOPIC_NAME` (required)
- `NTFY_URL` (defaults to `https://ntfy.sh`)
- `LISTEN_PORT` (defaults to `5000`)

#### Minimal docker compose example

``` docker
---
services:
  ntfyrr:
    image: docker.io/leukosaima/ntfyrr:latest
    container_name: ntfyrr
    environment:
      - TOPIC_NAME=my-ntfy-topic
    ports:
      - 50550:5000
    restart: unless-stopped
```

#### Usage

Setup Webhook notifications in Overseerr, and use webhook URL `http://ntfyrr:5000/overseerr` within the same docker network, or `http://<host-ip>:50550/overseerr` within the LAN, for example.

---

This repo is a work in progress.
More documentation to come...
