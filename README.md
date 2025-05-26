# ntfyrr

A bridge between some services' webhook notifications to ntfy, for those that don't currently support ntfy natively.

Have the service send its default json payload as a webhook to ntfyrr, and ntfyrr will format it nicer and forward the notification to your ntfy instance.

---

### Services supported

- Overseerr
- Maintainerr (experimental)

#### Environment Variables to define when running ntfyrr

- `NTFY_URL` (defaults to `https://ntfy.sh`)
- `LISTEN_PORT` (defaults to `5000`) - The port ntfyrr listens on inside the container, at the docker network level
- `OVERSEERR_TOPIC` (defaults to `overseerr`)
- `OVERSEERR_URL` (optional) - To provide a link in the notification to visit your overseerr instance 
- `MAINTAINERR_TOPIC` (defaults to `maintainerr`, experimental)
- `MAINTAINERR_URL` (optional, experimental)

#### Docker compose examples

##### Minimal

``` docker
---
services:
  ntfyrr:
    image: docker.io/leukosaima/ntfyrr:latest
    container_name: ntfyrr
    environment:
      - OVERSEERR_TOPIC=my-ntfy-topic
    ports:
      - 50550:5000
    restart: unless-stopped
```

##### Self-hosted ntfy

``` docker
---
services:
  ntfyrr:
    image: docker.io/leukosaima/ntfyrr:latest
    container_name: ntfyrr
    environment:
      - OVERSEERR_TOPIC=my-ntfy-topic
      - NTFY_URL=http(s)://my-ntfy-host:port
      - OVERSEERR_URL=http(s)//my-ovsr-host:port
    volumes:
      - /path/to/user-credentials.json:/run/secrets/user-credentials.json:ro
    ports:
      - 50550:5000
    restart: unless-stopped
```

##### user-credentials.json contents

For restricted topics
``` json 
{
    "username": "your_username",
    "password": "your_password",
    "token": ""
}
```
OR
``` json 
{
    "username": "",
    "password": "",
    "token": "your_token"
}
```
Auth via token will take precedence over username + password if all are defined.

### Usage

#### Overseerr

Setup Webhook notifications in Overseerr using the default payload it provides. Use webhook URL `http://ntfyrr:5000/overseerr` within the same docker network, or `http://<host-ip>:50550/overseerr` within the LAN, for example.

#### Maintainerr

Setup Webhook notifications, use webhook URL `http://ntfyrr:5000/maintainerr` within the same docker network, or `http://<host-ip>:50550/maintainerr` within the LAN, for example.