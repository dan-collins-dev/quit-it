<script>
	let { trigger, id, onDelete, onEdit } = $props();
	let isEditing = $state(false);
	let isDisabled = $state(true);

	function toggleEditMode() {
		isEditing = !isEditing;
		if (isEditing) {
			isDisabled = false;
		} else {
			isDisabled = true;
		}
        // document.getElementById("test").showModal();
	}

	function handleEdit(id) {
		onEdit(id, trigger);
		toggleEditMode();
	}
</script>

<section>
	<!-- <h1>Triggers</h1>
    <input type="text">
    <button></button> -->
	<input type="text" bind:value={trigger} name="" disabled={isDisabled} />
	{#if !isEditing}
		<button onclick={() => toggleEditMode()}>Edit</button>
		<button onclick={() => onDelete(id)}>Delete</button>
	{:else}
		<button onclick={() => handleEdit(id)}>Save</button>
		<button onclick={() => toggleEditMode()}>Cancel</button>
	{/if}
    <dialog id="test">
        <h1>hi</h1>
    </dialog>
</section>

<style>
	section {
		display: grid;
		grid-template-columns: 1fr;
		color: black;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
	}
</style>
